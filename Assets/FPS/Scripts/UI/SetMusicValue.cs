using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.UI;

public class SetMusicValue : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float volume;

    private void Awake()
    {
        volume = PlayerPrefs.GetFloat("volume");
        if (slider != null)
        {            
            slider.value = volume;
        }        
    }

    public void SaveMusicVolume()
    {
        volume = slider.value;        
        PlayerPrefs.SetFloat("volume", volume);        
    }
}
