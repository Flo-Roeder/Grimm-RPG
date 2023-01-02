using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreGameStatHandler : MonoBehaviour
{

    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerStats defaultStats;

    [SerializeField] TextMeshProUGUI maxHealthText;
    [SerializeField] TextMeshProUGUI armorText;
    [SerializeField] TextMeshProUGUI maxStaminaText;
    [SerializeField] TextMeshProUGUI regenStaminaText;
    [SerializeField] TextMeshProUGUI moveSpeedText;
    [SerializeField] TextMeshProUGUI dashSpeedText;
    [SerializeField] TextMeshProUGUI dashCooldownText;
    [SerializeField] TextMeshProUGUI dashStaminaCostText;
    [SerializeField] TextMeshProUGUI attackDamgeText;
    [SerializeField] TextMeshProUGUI critChanceText;
    [SerializeField] TextMeshProUGUI critMultiText;
    [SerializeField] TextMeshProUGUI attackStaminaCostText;
    [SerializeField] TextMeshProUGUI knockbackForceText;
    [SerializeField] TextMeshProUGUI knockbackTimeText;






    // Start is called before the first frame update
    void Start()
    {
        ResetToDefault();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MaxHealthChange(int value) 
    {
        playerStats.maxHealth+=value;
        UpdateUI();
    }

    public void ArmorChange(int value)
    {
        playerStats.armor+=value;
        UpdateUI();
    }

    public void MaxStaminaChange(int value)
    {
        playerStats.maxStamina+=value;
        UpdateUI();
    }

    public void RegenStaminaChange(int value) 
    {
        playerStats.regenStamina+=value;
        UpdateUI();
    }

    public void MoveSpeedChange(int value)
    {
        playerStats.moveSpeed+=value;
        UpdateUI();
    }


    public void DashSpeedChange(int value)
    {
        playerStats.dashSpeed+=value;
        UpdateUI();
    }


    public void DashCooldownChange(float value)
    {
        playerStats.dashCooldown+=value;
        UpdateUI();
    }


    public void DashStaminaCostChange(int value) 
    {
        playerStats.dashStaminaCost+=value;
        UpdateUI();
    }

    public void AttackDamageChange(int value)
    {
        playerStats.attackDamage+=value;
        UpdateUI();
    }

    public void CritChanceChange(int value)
    {
        playerStats.critChancePercentage+=value;
        UpdateUI();
    }

    public void CritMultiChange(int value)
    {
        playerStats.critMultiplier += value;
        UpdateUI();
    }

    public void AttackStaminaCost(int value)
    {
        playerStats.attackStaminaCost+=value;
        UpdateUI();
    }

    public void KnockbackAmountChange(int value)
    {
        playerStats.knockbackAmount+=value;
        UpdateUI();
    }

    public void KnockbackTimeChange(int value)
    {
        playerStats.knockbackTime+=value;
        UpdateUI();
    }

    public void ResetToDefault()
    {
        playerStats.maxHealth=defaultStats.maxHealth;
        playerStats.armor=defaultStats.armor;
        playerStats.maxStamina=defaultStats.maxStamina;
        playerStats.regenStamina=defaultStats.regenStamina;
        playerStats.moveSpeed=defaultStats.moveSpeed;
        playerStats.dashSpeed=defaultStats.dashSpeed;
        playerStats.dashCooldown=defaultStats.dashCooldown;
        playerStats.dashStaminaCost=defaultStats.dashStaminaCost;
        playerStats.attackDamage=defaultStats.attackDamage;
        playerStats.critChancePercentage=defaultStats.critChancePercentage;
        playerStats.critMultiplier=defaultStats.critMultiplier;
        playerStats.attackStaminaCost= defaultStats.attackStaminaCost;
        UpdateUI();
    }

    private void UpdateUI() 
    {
        maxHealthText.text = playerStats.maxHealth.ToString();
        moveSpeedText.text = playerStats.moveSpeed.ToString();
        dashSpeedText.text = playerStats.dashSpeed.ToString();
        dashCooldownText.text = playerStats.dashCooldown.ToString();
        dashStaminaCostText.text = playerStats.dashStaminaCost.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
