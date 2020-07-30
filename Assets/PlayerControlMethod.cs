using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


// changing this file 
// test git vsc


public class PlayerControlMethod : MonoBehaviour
{
    private Transform _camTransform;
    private Vector3 _moveVector;

    private Vector3 _inputDirection;
    public float moveSpeed = 5f;
    private Quaternion _currentRotation;
    private Vector2 _moveInput;
    private Vector3 _desiredDirection;
    private Vector2 _mousePosition;
    private float rotateSpeed = 4;

    private void Awake()
    {
        if (Camera.main != null) _camTransform = Camera.main.transform;
        
    }
    
    private void FixedUpdate()
    {
        // translate old vector2 to vector3
        float horizontal = _moveInput.x;
        float vertical = _moveInput.y;
        Vector3 targetInput = new Vector3(horizontal,0,vertical);
         
        // this step adds smoothness into routes by  
        _inputDirection = Vector3.Lerp(_inputDirection, targetInput, Time.deltaTime * 10f);
        //_inputDirection = targetInput;
        
        // collect camera data for turning
        Vector3 camForward = _camTransform.forward;
        Vector3 camRight = _camTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        
        _desiredDirection = camForward * _inputDirection.z + camRight * _inputDirection.x;
        Move(_desiredDirection);
        Turn(_desiredDirection);

        
        
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("rightmouse clicked");
            _lookRotationEnabled = true;
        }
        else if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            Debug.Log("right mouse released");
            _lookRotationEnabled = false;
        }

        if (_lookRotationEnabled)
        {
            LookAround(_mRotation);
            //Debug.Log("right button pressed");
        }
        

        
        // if (Mouse.current.rightButton.wasPressedThisFrame)
        // {
        //     Debug.Log("right button pressed, processing rotation on camera");
        //     LookAround(_mRotation);
        // }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 5f);
    }


    /// <summary>
    /// movement method
    /// </summary>
    /// <param name="direction"></param>
    private void Move(Vector3 direction)
    {
        _moveVector.Set(direction.x,0f,direction.z);
        _moveVector = _moveVector * (moveSpeed * Time.deltaTime);
        transform.position += _moveVector;
    }

    /// <summary>
    /// Turning method
    /// </summary>
    /// <param name="direction"></param>
    private void Turn(Vector3 direction)
    {
        if (direction.x > 0.1 || direction.x < -0.1 || direction.z > 0.1 ||
            direction.z< -0.1)
        {
            _currentRotation = Quaternion.LookRotation(direction);
        }
        transform.rotation = _currentRotation;
    }

    private Vector3 _mRotation;
    bool _lookRotationEnabled = false;
    /// <summary>
    /// LookAround Method for Camera
    /// </summary>
    /// <param name="rotate"></param>
    private void LookAround(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < 0.01)
            return;
        var scaledRotateSpeed = rotateSpeed * Time.deltaTime;
        
        // reverse x rotation
        _mRotation.x = -rotate.y * scaledRotateSpeed;

        _mRotation.y = rotate.x * scaledRotateSpeed;
        //Mathf.Clamp(_mRotation.x - rotate.y * scaledRotateSpeed, -89, 89);
        
        _camTransform.localEulerAngles += _mRotation;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
        //Debug.Log("User pressed movement key: " + _moveVector);
    }


    public void OnLook(InputAction.CallbackContext ctx)
    {
            _mRotation = ctx.ReadValue<Vector2>();    
        
        //Debug.Log(_mRotation);
    }
}