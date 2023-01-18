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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void StartAbility(GameObject parent)
    {
        PlayerController player = parent.GetComponent<PlayerController>();

        if (staminaCost <= playerStats.currentStamina
            && player.anim.GetBool(AnimStrings.canMove))
        {
            player.anim.SetTrigger(AnimStrings.isBlocking);

            playerStats.currentStamina -= staminaCost;
            //player.healthController.TakeStamina(staminaCost, false);
            blockInstance = Instantiate(blockGameobject,parent.transform);
            blockInstance.transform.localScale=new Vector3(radius, radius, 0);
            blockInstance.GetComponent<BlockPush>().knockbackTime = activeTime;
            blockInstance.GetComponent<BlockPush>().knockbackAmount= pushAmount;
        }
    }

    public override void StopAbility(GameObject parent)
    {
        Destroy(blockInstance);
    }

    public override void RefreshAbility(GameObject parent)
    {
        PlayerController player = parent.GetComponent<PlayerController>();
        //player.healthController.TakeStamina(0, true);
    }


}
