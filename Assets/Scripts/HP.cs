using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public Slider slider;

    public void Update()
    {
        if(slider.value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void setDefaultHealthPoint(float healthpoint)
    {
        slider.maxValue = healthpoint;
        slider.value = healthpoint;
    }

    public float getHealthPoint()
    {
        return slider.value;
    }

    public void setHealthPoint(float healthpoint)
    {
        slider.value = healthpoint;
    }

    public void loseHealth(float damage)
    {
        slider.value -= damage;
    }
}
