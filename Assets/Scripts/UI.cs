using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText = default;
    [SerializeField] private TextMeshProUGUI staminaText = default;
    [SerializeField] private Slider healthSlider = default;
    [SerializeField] private Slider staminaSlider = default;

    private void OnEnable()
    {
        FirstPersonController.OnDamage += UpdateHealth;
        FirstPersonController.OnHeal += UpdateHealth;
        FirstPersonController.OnStaminaChange += UpdateStamina;
    }
    private void OnDisable()
    {
        FirstPersonController.OnDamage -= UpdateHealth;
        FirstPersonController.OnHeal -= UpdateHealth;
        FirstPersonController.OnStaminaChange -= UpdateStamina;
    }
    private void Start()
    {
        UpdateHealth(100);
        UpdateStamina(100);
    }
    private void UpdateHealth(float currentHealth)
    {
        healthSlider.value = currentHealth;
        healthText.text = currentHealth.ToString("00");
    }
    private void UpdateStamina(float currentStamina)
    {
        staminaSlider.value = currentStamina;
        staminaText.text = currentStamina.ToString("00");
    }
}
