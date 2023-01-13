﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "GearInventory")]
public class GearInventory : ScriptableObject
{
    //public Dictionary<string,int> inventoryList= new();

    public GameObject helmet, armor, shoes, weapon, jewelery;
    public PlayerStats playerStats;
    [SerializeField] GameObject defaultGear;



    private void Awake()
    {
        Debug.Log("Awake");
        //weapon = defaultWeapon;
    }

    public void ResetGear()
    {
        helmet = defaultGear;
        armor=defaultGear;
        shoes=defaultGear;
        weapon=defaultGear;
        jewelery=defaultGear;
    }

    public void PicUpNewWeapon(GameObject _newGear)
    {
        GearPickUp gearStats = weapon.GetComponent<GearPickUp>();
        RemoveOldStats(gearStats);
        GameObject newWeapon = Instantiate(weapon, _newGear.transform.position, Quaternion.identity);
        newWeapon.SetActive(true);
        weapon = _newGear;
        gearStats = weapon.GetComponent<GearPickUp>();
        AddNewStats(gearStats);
    }

    public void PicUpNewArmor(GameObject _newGear)
    {
        GearPickUp gearStats = armor.GetComponent<GearPickUp>();
        RemoveOldStats(gearStats);
        GameObject newWeapon = Instantiate(armor, _newGear.transform.position, Quaternion.identity);
        newWeapon.SetActive(true);
        armor = _newGear;
        gearStats = armor.GetComponent<GearPickUp>();
        AddNewStats(gearStats);
    }

    public void PicUpNewHelmet(GameObject _newGear)
    {
        GearPickUp gearStats = helmet.GetComponent<GearPickUp>();
        RemoveOldStats(gearStats);
        GameObject newWeapon = Instantiate(helmet, _newGear.transform.position, Quaternion.identity);
        newWeapon.SetActive(true);
        helmet = _newGear;
        gearStats = helmet.GetComponent<GearPickUp>();
        AddNewStats(gearStats);
    }

    public void PicUpNewShoes(GameObject _newGear)
    {
        GearPickUp gearStats = shoes.GetComponent<GearPickUp>();
        RemoveOldStats(gearStats);
        GameObject newWeapon = Instantiate(shoes, _newGear.transform.position, Quaternion.identity);
        newWeapon.SetActive(true);
        shoes = _newGear;
        gearStats = shoes.GetComponent<GearPickUp>();
        AddNewStats(gearStats);
    }

    public void PicUpNewJewelery(GameObject _newGear)
    {
        GearPickUp gearStats = jewelery.GetComponent<GearPickUp>();
        RemoveOldStats(gearStats);
        GameObject newWeapon = Instantiate(jewelery, _newGear.transform.position, Quaternion.identity);
        newWeapon.SetActive(true);
        jewelery = _newGear;
        gearStats = jewelery.GetComponent<GearPickUp>();
        AddNewStats(gearStats);
    }


    private void AddPlayerStats(int maxHealth, int armor, int maxStamina, int staminaReg, int moveSpeed,
                                int dashSpeed, int dashStamina, int attackDamage, int critChance, float critMulti,
                                int attackStamina, int knockbackAmount)
    {
        playerStats.MaxHealthChange(maxHealth);
        playerStats.ArmorChange(armor);
        playerStats.MaxStaminaChange(maxStamina);
        playerStats.RegenStaminaChange(staminaReg);
        playerStats.MoveSpeedChange(moveSpeed);
        playerStats.DashSpeedChange(dashSpeed);
        //        playerStats.DashCooldownChange(dashStamina);
        playerStats.DashStaminaCostChange(dashStamina);
        playerStats.AttackDamageChange(attackDamage);


        playerStats.CritChanceChange(critChance);
        playerStats.CritMultiChange(critMulti);
        playerStats.AttackStaminaCost(attackStamina);
        playerStats.KnockbackAmountChange(knockbackAmount);
        
        //public void KnockbackTimeChange(float value)

        
    }

    private void RemoveOldStats(GearPickUp gearStats)
    {
        AddPlayerStats(-gearStats.maxHealth, -gearStats.armor, -gearStats.maxStamina, -gearStats.staminaReg, -gearStats.moveSpeed,
                    -gearStats.dashSpeed, -gearStats.dashStamina, -gearStats.attackDamage, -gearStats.critChance, -gearStats.critMulti,
                    -gearStats.attackStamina, -gearStats.knockbackAmount);
    }

    private void AddNewStats(GearPickUp gearStats)
    {
        AddPlayerStats(gearStats.maxHealth, gearStats.armor, gearStats.maxStamina, gearStats.staminaReg, gearStats.moveSpeed,
                                gearStats.dashSpeed, gearStats.dashStamina, gearStats.attackDamage, gearStats.critChance, gearStats.critMulti,
                                gearStats.attackStamina, gearStats.knockbackAmount);
    }

}
