using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMusicValue : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float volume;

    private void Awake()
    {
        if(slider != null)
        {
            volume = PlayerPrefs.GetFloat("musicVolume");
            slider.value = volume;
        }       
    }

    public void SaveMusicVolume()
    {
        volume = slider.value;
        volume = Mathf.Clamp01(volume);
        PlayerPrefs.SetFloat("musicVolume", volume);        
    }
}
