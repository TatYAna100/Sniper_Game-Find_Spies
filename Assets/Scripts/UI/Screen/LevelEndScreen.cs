using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndScreen : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.LevelEnd += OnLevelEnd;
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.LevelEnd -= OnLevelEnd;
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    private void OnLevelEnd() { }

    private void OnContinueButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnMenuButtonClick()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }
}