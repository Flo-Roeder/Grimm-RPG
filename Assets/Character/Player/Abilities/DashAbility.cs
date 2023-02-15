using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

[CreateAssetMenu(menuName ="Ability/DashAbility")]
public class DashAbility : Ability
{

    [SerializeField] float dashSpeed;
    [SerializeField] string debug;





    public override void CastingAbility(GameObject parent)
    {
        parent.GetComponent<Animator>().SetBool(AnimStrings.abilityActive,true);

    }

    public override void StartAbility(GameObject parent)
    {
        PlayerController player = parent.GetComponent<PlayerController>();

        if (staminaCost <= playerStats.currentStamina)
        {
            player.anim.SetTrigger(AnimStrings.isDashing);
            player.appliedDashForce = new Vector2(Mathf.Abs(player.anim.GetFloat(AnimStrings.xVelocity)), Mathf.Abs(player.anim.GetFloat(AnimStrings.yVelocity))) * dashSpeed;

            player.healthController.TakeStamina(staminaCost, false);

        }
    }

    public override void StopAbility(GameObject parent)
    {
        PlayerController player = parent.GetComponent<PlayerController>();

        player.appliedDashForce = Vector2.zero;
    }

    public override void RefreshAbility(GameObject parent)
    {
        PlayerController player = parent.GetComponent<PlayerController>();
        player.healthController.TakeStamina(0, true);
    }
}
