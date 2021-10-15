using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string levelToLoad;

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(levelToLoad);
            
        }
    }
}
