using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetSoundsVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;

    public void SetMainVolume(float sliderValue)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20f);
    }
    public void SetSoundFXVolume(float sliderValue)
    {
        mainMixer.SetFloat("SoundFXVolume", Mathf.Log10(sliderValue) * 20f);
    }
    public void SetMusicVolume(float sliderValue)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20f);
    }
}
