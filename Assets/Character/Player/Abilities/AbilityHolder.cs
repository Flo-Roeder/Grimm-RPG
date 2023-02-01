using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[System.Serializable]
public class AbilityHolder:MonoBehaviour
{
    public Ability ability;
    public Ability primary, secondary, terc;
    [SerializeField] bool started;

    [SerializeField]float activeTime;
    [SerializeField]float coolDownTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    [SerializeField] AbilityState state = AbilityState.ready;
    [SerializeField] Image cooldownImage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case AbilityState.ready:
                if(started)
                {
                    activeTime = ability.activeTime;
                    ability.StartAbility(gameObject);
                    state = AbilityState.active;
                    cooldownImage.fillAmount = 1;
                    cooldownImage.color=new Color(220,220,150,0.20f);
                }

                break;

            case AbilityState.active:
                activeTime -= Time.deltaTime;
                if (activeTime <= 0)
                {
                    coolDownTime = ability.coolDown;
                    state = AbilityState.cooldown;
                    ability.StopAbility(gameObject);

                }
                break;

            case AbilityState.cooldown:
                coolDownTime -= Time.deltaTime;
                cooldownImage.color = new Color(0, 0, 0, 0.70f);
                cooldownImage.fillAmount = coolDownTime/ ability.coolDown;

                if (coolDownTime <= 0)
                {
                    state = AbilityState.ready;
                    ability.RefreshAbility(gameObject);
                    cooldownImage.fillAmount = 0;
                }
                break;

            default:
                break;

        }
    }

    public void Activate(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            started = true;
            StartCoroutine(ActivateCo());
        }

    }

    private IEnumerator ActivateCo()
    {
        yield return null;
        started = false;
    }



}
