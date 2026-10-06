using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderAudioMixer : MonoBehaviour
{
    private const int MinimumVolume = -80;
    private const int MaximumVolume = 0;
    private const int VolumeCoef = 20;
    
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _volumeString;
    
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {        
        if (value == MaximumVolume)
            _mixer.SetFloat(_volumeString, MinimumVolume);
        else
            _mixer.SetFloat(_volumeString, Mathf.Log10(value) * VolumeCoef);
    }
}
