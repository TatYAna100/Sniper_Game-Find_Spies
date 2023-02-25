using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimeCount _timer;
    [SerializeField] private TMP_Text _timerText;

    private void OnEnable()
    {
        _timer.TimerChanged += OnTimerChanged;
    }

    private void OnDisable()
    {
        _timer.TimerChanged -= OnTimerChanged;
    }

    private void OnTimerChanged(float time)
    {
        _timerText.text = time.ToString();
    }
}