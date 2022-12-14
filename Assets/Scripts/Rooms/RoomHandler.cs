using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject activateOnClear;
   // [SerializeField] GameObject deactivateOnClear;
    [SerializeField] GameObject activateOnStart;
   // [SerializeField] GameObject deactivateOnStart;

    [SerializeField] private bool roomCleared;
    public bool roomStarted;

    public float trackEnemiesDelay=1f;
    private void Awake()
    {
   //     deactivateOnClear.SetActive(true);
        activateOnClear.SetActive(false);
        activateOnStart.SetActive(false);
    //    deactivateOnStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (roomStarted)
        {
            activateOnStart.SetActive(true);
     //       deactivateOnStart.SetActive(false);
            trackEnemiesDelay -= Time.deltaTime;
            if (trackEnemiesDelay<=0)
            {
            TrackEnemies();

            }
        }
        
        if (roomCleared)
        {
    //        deactivateOnClear.SetActive(false);
            activateOnClear.SetActive(true);
        }

    }

    private void TrackEnemies()
    {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length==0 )
            {
                roomCleared = true;
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
            && !roomStarted)
        {
            roomStarted = true;
        }
    }


}
