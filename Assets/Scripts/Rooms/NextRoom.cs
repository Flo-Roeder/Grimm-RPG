using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    [SerializeField] ScriptableRoom randomroomTemplate;
    [SerializeField] Transform roomSpawnPoint;
    Animator fadeCanvasAnimator;

    private GameObject player;

    private void Awake()
    {
        fadeCanvasAnimator = GameObject.FindGameObjectWithTag("FadeCanvas").GetComponent<Animator>();
        //fadeCanvasAnimator.SetTrigger(AnimStrings.fadeIn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            StartCoroutine(NextRoomCo());
            randomroomTemplate.GenerateRoom(roomSpawnPoint);
            fadeCanvasAnimator.SetTrigger(AnimStrings.fadeOut);
        }
    }

    private IEnumerator NextRoomCo()
    {
        player.GetComponent<Animator>().SetBool(AnimStrings.canMove, false);
        yield return new WaitForSeconds(.5f);
        Transform playTrans = player.GetComponent<Transform>();
        playTrans.position = roomSpawnPoint.position;
        player.GetComponent<Animator>().SetBool(AnimStrings.canMove, true);
        GameObject.FindGameObjectWithTag("LevelUI").GetComponentInChildren<LevelUI>().NextRoomUpdateLevelUI();
    }
}
