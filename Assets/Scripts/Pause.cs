using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    void ContinueGame()
    {
        Time.timeScale = 1;
    }

    void QuitGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
