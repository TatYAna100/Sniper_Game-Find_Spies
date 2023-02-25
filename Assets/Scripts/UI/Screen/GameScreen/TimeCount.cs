using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimeCount : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private LevelEndScreen _levelEndScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private float _currentTime;

    public event UnityAction<float> TimerChanged;
    public event UnityAction GameOver;

    private void Start()
    {
        _currentTime = _duration;

        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while (_currentTime != 0)
        {
            yield return new WaitForSeconds(1f);
            _currentTime--;
            TimerChanged?.Invoke(_currentTime);
        }

        if (_currentTime == 0 && _levelEndScreen.isActiveAndEnabled == false)
        {
            //GameOver?.Invoke();
            _gameOverScreen.gameObject.SetActive(true);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}