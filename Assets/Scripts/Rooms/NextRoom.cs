using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    [SerializeField] ScriptableRandomSpawn randomroomTemplate;
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
            fadeCanvasAnimator.SetTrigger(AnimStrings.fadeOut);
            StartCoroutine(NextRoomCo());
        }
    }

    private IEnumerator NextRoomCo()
    {
        player.GetComponent<Animator>().SetBool(AnimStrings.canMove, false);
        yield return new WaitForSeconds(.5f);
            Transform _playerTrans = player.GetComponent<Transform>();
        _playerTrans.position = Vector3.zero;
            GameObject _tempParent = new ("RoomSpawn");
        _tempParent.transform.position = Vector3.zero;
        randomroomTemplate.SpawnObject(_tempParent.transform);
        player.GetComponent<Animator>().SetBool(AnimStrings.canMove, true);
        GameObject.FindGameObjectWithTag("LevelUI").GetComponentInChildren<LevelUI>().NextRoomUpdateLevelUI();
        Destroy(transform.parent.gameObject);
    }
}
