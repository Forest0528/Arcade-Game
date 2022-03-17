using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    [SerializeField] public GameObject panelwin;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "PlayerTag")
        {
            panelwin.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
