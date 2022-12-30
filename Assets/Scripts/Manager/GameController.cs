using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int tempCounter;
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
}
