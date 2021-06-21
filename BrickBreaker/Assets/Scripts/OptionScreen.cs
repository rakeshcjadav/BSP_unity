using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionScreen : MonoBehaviour
{
    public Options options;
    public Slider MasterVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;

    void OnEnable()
    {
        MasterVolumeSlider.value = options.Master_Volume;
        MusicVolumeSlider.value = options.Music_Volume;
        SFXVolumeSlider.value = options.SFX_Volume;
    }
}
