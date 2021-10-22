using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{

    public GameObject victoryUI;
    public GameObject mainUI;

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            Time.timeScale = 0;
            PublicVars.paused = true;
            mainUI.SetActive(false);
            victoryUI.SetActive(true);
        }
    }
}
