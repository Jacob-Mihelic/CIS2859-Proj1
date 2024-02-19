using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider slider;
    
    public void SetHealth(int value)
    {
        slider.value = value;
    }

    public void LoseHealth(int dmg)
    {
        slider.value -= dmg;
    }

    public void Heal(int heal)
    {
        slider.value += heal;
    }
    
    public float GetHealth()
    {
        return slider.value;
    }
}
