using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    //0: Main
    //1: onlineSelection
    public GameObject[] menus;
    public void startAI()
    {
        StartCoroutine(LoadScene(aiSetup));
    }

    private void aiSetup()
    {
        SceneManager.Instance.turn.mode = "AI";
    }

    public void startLocal()
    {
       StartCoroutine(LoadScene(localSetup));
    }

    private void localSetup()
    {
        SceneManager.Instance.turn.mode = "twoPlayerLocal";
    }
    

   


    private IEnumerator LoadScene(Action cb, Action<string> cbs = null, string ip = "")
    {
        // Start loading the scene
        AsyncOperation asyncLoadLevel = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("main", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        
        // Wait until the level finish loading
        while (!asyncLoadLevel.isDone)
            yield return null;
        
        // Wait a frame so every Awake and Start method is called
        yield return new WaitForEndOfFrame();
        if (ip.Length > 0 && cbs != null)
            cbs(ip);
        else if(cb != null)
            cb();
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetSceneByName("Menu").buildIndex);
    }
}
