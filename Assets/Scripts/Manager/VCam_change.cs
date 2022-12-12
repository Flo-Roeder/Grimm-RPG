using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCam_change : MonoBehaviour
{

    [SerializeField]private GameObject vCam;
    private CinemachineConfiner2D vCamConfi;
    private CinemachineVirtualCamera virtualCamera;
    private Collider2D roomCollider;
    [SerializeField] float lensFOV;

    private void Awake()
    {
        roomCollider= GetComponent<Collider2D>();
        vCam = GameObject.FindGameObjectWithTag("VCam");
        vCamConfi = vCam.GetComponent<CinemachineConfiner2D>();
        virtualCamera = vCam.GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            vCamConfi.m_BoundingShape2D= roomCollider;
            virtualCamera.m_Lens.FieldOfView = lensFOV;

        }
    }

}
