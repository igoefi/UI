using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OnOffVolumeButton : MonoBehaviour
{
    private const int MinimumVolume = -80;
    
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _masterVolumeString;

    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnOffSound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnOffSound);
    }
    
    public void OnOffSound()
    {
        _mixer.GetFloat(_masterVolumeString, out float volume);
        int value = volume > MinimumVolume ? MinimumVolume : 0;
        _mixer.SetFloat(_masterVolumeString, value);
    }
}
