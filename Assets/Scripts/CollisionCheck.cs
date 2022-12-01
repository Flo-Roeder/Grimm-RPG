using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{

    [SerializeField] List<Collider> trigger3DList;
    [SerializeField] List<Collider2D> trigger2DList;

    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        trigger3DList.Add(other);

    }

    private void OnTriggerExit(Collider other)
    {
        trigger3DList.Remove(other);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger2DList.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger2DList.Remove(collision);
    }

}
