using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Create Option preset", fileName = "New Option Preset")]
public class Options : ScriptableObject
{
    public AudioMixer mixer;
    public string Name;
    public float Master_Volume;
    public float Music_Volume;
    public float SFX_Volume;

    public void InitVolumes()
    {
        OnMasterVolume_Updated(Master_Volume);
        OnMusicVolume_Updated(Music_Volume);
        OnSFXVolume_Updated(SFX_Volume);
    }

    public void OnMasterVolume_Updated(float volume)
    {
        Master_Volume = volume;
        float db = -80.0f * (1.0f - volume) + 0.0f * (volume);
        mixer.SetFloat("MasterVolume", db);
    }

    public void OnMusicVolume_Updated(float volume)
    {
        Music_Volume = volume;
        float db = -80.0f * (1.0f - volume) + 0.0f * (volume);
        mixer.SetFloat("MusicVolume", db);
    }

    public void OnSFXVolume_Updated(float volume)
    {
        SFX_Volume = volume;
        float db = -80.0f * (1.0f - volume) + 0.0f * (volume);
        mixer.SetFloat("SFXVolume", db);
    }
}
