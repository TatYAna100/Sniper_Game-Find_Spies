using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private Button _pauseButtom;
    [SerializeField] private PauseScreen _pauseScreen;

    private void OnEnable()
    {
        _pauseButtom.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnDisable()
    {
        _pauseButtom.onClick.RemoveListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        _pauseScreen.gameObject.SetActive(true);
    }
}