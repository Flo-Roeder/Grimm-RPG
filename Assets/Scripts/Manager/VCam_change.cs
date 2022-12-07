using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCam_change : MonoBehaviour
{

    [SerializeField]private CinemachineConfiner2D vCam;
    private Collider2D roomCollider;

    private void Awake()
    {
        roomCollider= GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            vCam.m_BoundingShape2D= roomCollider;
        }
    }

}
