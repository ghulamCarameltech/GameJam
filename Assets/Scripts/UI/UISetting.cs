using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private Slider _musicSlider;

    [SerializeField]
    private Slider _soundSlider;

    [SerializeField]
    private Toggle _vibration;

    void OnEnable()
    {
    //      _musicSlider.value = PlayerPrefsManager.GetMusicVolume();
    //     _soundSlider.value = PlayerPrefsManager.GetSoundVolume();
    //     _vibration.isOn = PlayerPrefsManager.GetVibration();
    }

    public void SetMusicVolume()
    {
        // SoundManager.SetMusicVolume(_musicSlider.value);
    }

    public void SetSoundVolume()
    {
        // SoundManager.SetSoundVolume(_soundSlider.value);
    }

    public void SetVibration()
    {
        // PlayerPrefsManager.SetVibration(_vibration.isOn);
    }

    public void LoadHomeScreen()
    {
        // uIManager.ShowScreen(UIManager.UIs.MainMenu);
    }
}
