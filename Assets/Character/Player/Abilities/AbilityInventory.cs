using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AbilityInventory")]
public class AbilityInventory : ScriptableObject
{
    public GameObject primary, secondary, terc;
    [SerializeField] GameObject defaultAbility;
    // Start is called before the first frame update
    
    public void ResetAbility()
    {
        primary = defaultAbility;
        secondary = defaultAbility;
        terc= defaultAbility;
    }

    public void PickUpNewPrimary(GameObject _newAbility, Transform parent)
    {
        GameObject oldAbility = Instantiate(primary, _newAbility.transform.position, Quaternion.identity);
        oldAbility.transform.parent = parent;
        oldAbility.SetActive(true);
        primary= _newAbility;
        AbilityHolder abilityHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityHolderPrime>();
        abilityHolder.primary = primary.GetComponent<AbilityPickUp>().ability;
    }
   
    public void PickUpNewSecondary(GameObject _newAbility, Transform parent)
    {
        GameObject oldAbility = Instantiate(secondary, _newAbility.transform.position, Quaternion.identity);
        oldAbility.transform.parent = parent;
        oldAbility.SetActive(true);
        secondary = _newAbility;
        AbilityHolder abilityHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityHolderSecond>();
        //abilityHolder.secondary = secondary.GetComponent<AbilityPickUp>().ability;
        Ability ability = secondary.GetComponent<AbilityPickUp>().ability;
        abilityHolder.ability= ability;
    }
    
    public void PickUpNewTerc(GameObject _newAbility, Transform parent)
    {
        GameObject oldAbility = Instantiate(terc, _newAbility.transform.position, Quaternion.identity);
        oldAbility.transform.parent = parent;
        oldAbility.SetActive(true);
        terc = _newAbility;
        AbilityHolder abilityHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityHolderTerc>();
        abilityHolder.terc = terc.GetComponent<AbilityPickUp>().ability;
    }


}
