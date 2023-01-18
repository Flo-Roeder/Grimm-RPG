using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMultiplier : MonoBehaviour
{

    [SerializeField] EnemyHealthController healthController;
    [SerializeField] GameObject[] spawnOnDeath;
    [SerializeField] float sizeDownSclaing;
    [SerializeField] int healthDownScaling;
    [SerializeField] int attackDownScaling;
    public int maxWaves;
    public int waveCounter;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealthController.DeathEventTrigger += Multiplie;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Multiplie()
    {
        if (healthController.currentHealth <= 0)
        {
            foreach (var item in spawnOnDeath)
            {
                if (waveCounter<maxWaves)
                {
                    GameObject _instance = Instantiate(item,transform.position,Quaternion.identity);
                    _instance.GetComponent<EnemyMultiplier>().waveCounter= waveCounter+1;
                    int _maxHealth = _instance.GetComponent<EnemyHealthController>().maxHealth/=healthDownScaling;
                    _instance.GetComponent<EnemyHealthController>().currentHealth = _maxHealth;
                    _instance.transform.localScale /= sizeDownSclaing;
                    _instance.GetComponentInChildren<Attack>().damage /= attackDownScaling;
                    EnemyHealthController.DeathEventTrigger -= Multiplie;
                }
            }
        }
    }
}
