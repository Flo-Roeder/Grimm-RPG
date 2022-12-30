using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    }

    public void TimeChange() 
    {
        Time.timeScale = Time.timeScale == 1 ? .5f : 1;
    }

    public void ReloadRun(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void QuitToDesktop()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        float tempValue=context.ReadValue<float>();
        vCam.m_Lens.OrthographicSize = Mathf.Clamp(vCam.m_Lens.OrthographicSize+tempValue,10f,20f);
    }
}
