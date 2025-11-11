using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    public void SetSlider(float amount)
    {
        healthBar.value = amount;
    }
    public void SetSliderMax(float amount)
    {
        healthBar.maxValue = amount;
        SetSlider(amount);
    }
}
