using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OnOffVolumeButton : MonoBehaviour
{
    [SerializeField] private AudioListener _listener;

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
    
    public void OnOffSound() =>
        _listener.enabled = !_listener.enabled;
}
