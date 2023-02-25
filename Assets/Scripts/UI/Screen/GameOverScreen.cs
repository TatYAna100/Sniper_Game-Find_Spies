using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartButtom;
    [SerializeField] private Button _menuButtom;
    [SerializeField] private TimeCount _timeCount;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private int _menuScreen = 0;

    private void OnEnable()
    {
        _timeCount.GameOver += OnGameOver;
        _restartButtom.onClick.AddListener(OnRestartButtonClick);
        _menuButtom.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _timeCount.GameOver -= OnGameOver;
        _restartButtom.onClick.RemoveListener(OnRestartButtonClick);
        _menuButtom.onClick.RemoveListener(OnMenuButtonClick);
    }

    private void OnGameOver() { }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMenuButtonClick()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(_menuScreen);
    }
}