using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderAudioMixer : MonoBehaviour
{
    private const int MinimumVolume = -80;
    
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _volumeString;
    
    private Slider _slider;

    private void Awake() =>
        GetComponent<Slider>().onValueChanged.AddListener(ChangeVolume);

    private void ChangeVolume(float value)
    {        
        if (value == 0)
            _mixer.SetFloat(_volumeString, MinimumVolume);
        else
            _mixer.SetFloat(_volumeString, Mathf.Log10(value) * 20);
    }
}
