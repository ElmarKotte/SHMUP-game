using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarScript : MonoBehaviour
{

    public Slider slider;
    // Start is called before the first frame update


    public void SetMaxHealt(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
        
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
