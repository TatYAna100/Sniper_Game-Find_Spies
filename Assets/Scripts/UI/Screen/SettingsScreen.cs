using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private Button _exitButtom;
    [SerializeField] private Button _soundsOnButton;
    [SerializeField] private Button _soundsOffButton;
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private void OnEnable()
    {
        _soundsOnButton.onClick.AddListener(OnSoundsOnButtonClick);
        _soundsOffButton.onClick.AddListener(OnSoundsOffButtonClick);
        _exitButtom.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _soundsOnButton.onClick.RemoveListener(OnSoundsOnButtonClick);
        _soundsOffButton.onClick.RemoveListener(OnSoundsOffButtonClick);
        _exitButtom.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _soundsOnButton.gameObject.SetActive(true);
        _audioSource.volume = _maxVolume;
    }

    private void OnSoundsOnButtonClick()
    {
        _soundsOnButton.gameObject.SetActive(false);
        _soundsOffButton.gameObject.SetActive(true);
        _audioSource.volume = _minVolume;
    }

    private void OnSoundsOffButtonClick()
    {
        _soundsOffButton.gameObject.SetActive(false);
        _soundsOnButton.gameObject.SetActive(true);
        _audioSource.volume = _maxVolume;
    }

    private void OnExitButtonClick()
    {
        this.gameObject.SetActive(false);
    }
}