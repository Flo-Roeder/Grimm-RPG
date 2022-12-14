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

    public void SetHealthUI(float maxHealth, float currentHealth, bool isPlayer)
    {
        healthSlider.value = currentHealth / maxHealth;
        if (isPlayer)
        {
        healthTextMesh.text = currentHealth + "/" + maxHealth;
        }
        else
        {
            healthTextMesh.text = currentHealth.ToString();
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
