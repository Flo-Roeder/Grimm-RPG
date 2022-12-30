using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthTextMesh;
    [SerializeField] Slider healthSlider;

    [SerializeField] Slider staminaSlider;
    [SerializeField] GameObject dashCooldownImage;

    private void Update()
    {
        
    }

    public void SetHealthUI(float _maxHealth, float _currentHealth, bool isPlayer)
    {
        healthSlider.value = _currentHealth / _maxHealth;
        if (isPlayer)
        {
            healthTextMesh.text = _currentHealth + "/" + _maxHealth;
        }
        else
        {
            healthTextMesh.text = _currentHealth.ToString();
        }
    }

    public void SetStaminaUI(float maxStamina,float currentStamina, bool canDash)
    {
        staminaSlider.value= currentStamina/ maxStamina;
        if (canDash)
        {
            dashCooldownImage.SetActive(false);
        }
        else
        {
            dashCooldownImage.SetActive(true);
        }
    }


}
