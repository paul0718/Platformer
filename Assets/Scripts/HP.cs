using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider slider;

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
}
