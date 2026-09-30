using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIMixersHandler : MonoBehaviour
{
    private const int MinimumVolume = -80;
    private const string MasterVolumeString = "MasterVolume";
    private const string BGMVolumeString = "BGMVolume";
    private const string ButtonsVolumeString = "ButtonsVolume";

    [SerializeField] private TMP_Text _onOffSoundText;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _buttonsAudioSource;
    [SerializeField] private Slider _generalVolumeSlider;

    public void OnOffSound()
    {
        _mixer.GetFloat(MasterVolumeString, out float volume);

        int value = volume > MinimumVolume ? 0 : 1;

        SetVolume(MasterVolumeString, value);
        _generalVolumeSlider.value = value;
    }

    public void PlayButtonSong(AudioClip audioClip) =>
        _buttonsAudioSource.PlayOneShot(audioClip);

    public void SetMasterVolume(Slider slider) =>
        SetVolume(MasterVolumeString, slider.value);

    public void SetBGMVolume(Slider slider) =>
        SetVolume(BGMVolumeString, slider.value);

    public void SetButtonsVolume(Slider slider) =>
        SetVolume(ButtonsVolumeString, slider.value);

    private void SetVolume(string name, float value)
    {
        if (value == 0)
            _mixer.SetFloat(name, MinimumVolume);
        else
            _mixer.SetFloat(name, Mathf.Log10(value) * 20);
    }
}
