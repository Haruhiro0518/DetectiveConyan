using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = MainSystemScript.audioVolume;
    }

    
    public void SetVolume()
    {
        MainSystemScript.audioVolume = slider.value;
    }
}
