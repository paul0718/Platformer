using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider slider;

    public void setDefaultHealthPoint(int healthpoint)
    {
        slider.maxValue = healthpoint;
        slider.value = healthpoint;
    }

    public void setHealthPoint(int healthpoint)
    {
        slider.value = healthpoint;
    }
}
