
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private CharacterStats characterStats;
    
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
        InitialHealthBar();
        Debug.Log(characterStats.CurrentHealth);
    }

    private void InitialHealthBar()
    {
        _slider.value = characterStats.CurrentHealth;
        _slider.maxValue = characterStats.MaxHealth;
    }

    private void Update()
    {
        _slider.value = characterStats.CurrentHealth;
    }
}
