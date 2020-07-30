using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField]
    Transform focus = default;

    [SerializeField, Range(1f, 20f)]
    float distance = 5f;
    
    void LateUpdate () {
        
        Vector3 focusPoint = focus.position;
        Vector3 lookDirection = transform.forward;
        //Debug.Log(transform.localPosition);
        transform.localPosition = focusPoint - lookDirection * distance;
    }
    
}
