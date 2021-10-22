using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gameover : MonoBehaviour
{


    public void ContinueGame()
    {
        Time.timeScale = 1;
        PublicVars.paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        PublicVars.paused = false;
        SceneManager.LoadScene("TitleScreen");
    }
}
