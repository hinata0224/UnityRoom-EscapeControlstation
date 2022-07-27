using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerController : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {
        
    }

    public void GoMain()
    {
        SceneManager.LoadSceneAsync("Main",LoadSceneMode.Single); 
    }
    public void GoStart()
    {
        SceneManager.LoadSceneAsync("Start",LoadSceneMode.Single);
    }

    public void GoClear()
    {
        SceneManager.LoadSceneAsync("Clear",LoadSceneMode.Single);
    }

    public void GoLoser()
    {
        SceneManager.LoadSceneAsync("Loose", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
