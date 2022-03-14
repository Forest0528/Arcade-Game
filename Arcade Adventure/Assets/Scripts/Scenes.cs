using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject loadingScreen;

    public void NextLevel(int _sceneNumber)
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(_sceneNumber);
        Time.timeScale = 1;
    }

 
}