using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    private void Start(){
        Time.timeScale = 1;
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(PublicVars.paused)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                PublicVars.paused = false;
            } else 
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                PublicVars.paused = true;
            }
        }
        if(FindObjectOfType<HP>().getHealthPoint() <= 0)
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }
    }
}
