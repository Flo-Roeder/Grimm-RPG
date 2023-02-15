using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("Ability/BlockAbility"))]
public class BlockAbility : Ability
{

    [SerializeField] GameObject blockGameobject;
    GameObject blockInstance;
    [SerializeField] int pushAmount;
    [SerializeField] int radius;


    public override void CastingAbility(GameObject parent)
    {
        if (staminaCost <= playerStats.currentStamina)
        {
            parent.GetComponent<Animator>().SetTrigger(AnimStrings.isBlocking);
        }
    }


    public override void StartAbility(GameObject parent)
    {

            playerStats.currentStamina -= staminaCost;
            blockInstance = Instantiate(blockGameobject,parent.transform);
            blockInstance.transform.localScale=new Vector3(radius, radius, 0);
            blockInstance.GetComponent<BlockPush>().knockbackTime = activeTime;
            blockInstance.GetComponent<BlockPush>().knockbackAmount= pushAmount;

        parent.GetComponent<Animator>().SetBool(AnimStrings.abilityActive, false);
    }

    public override void StopAbility(GameObject parent)
    {
        Destroy(blockInstance);


    }

    public override void RefreshAbility(GameObject parent)
    {
    }


}
