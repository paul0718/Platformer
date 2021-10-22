using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(PublicVars.paused == true){
            _audioSource.Pause();
        } else {
            _audioSource.UnPause();
        }
    }
}
