using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMusicVolume : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private float volume;

    private void Awake()
    {
        volume = PlayerPrefs.GetFloat("musicVolume", 0f);
        SetVolume();
    }
    
    public void SetVolume()
    {
        audioSource.volume = 1f - volume;
    }
}
