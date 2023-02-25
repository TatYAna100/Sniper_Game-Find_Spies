using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button _continueButtom;
    [SerializeField] private Button _settingsButtom;
    [SerializeField] private Button _menuButtom;
    [SerializeField] private Button _pauseButtom;
    [SerializeField] private SettingsScreen _settingsScreen;

    private int _menuScreenNumber = 0;

    private void OnEnable()
    {
        _continueButtom.onClick.AddListener(OnContinueButtonClick);
        _settingsButtom.onClick.AddListener(OnSettingsButtonClick);
        _menuButtom.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _continueButtom.onClick.RemoveListener(OnContinueButtonClick);
        _settingsButtom.onClick.RemoveListener(OnSettingsButtonClick);
        _menuButtom.onClick.RemoveListener(OnMenuButtonClick);
    }

    private void OnContinueButtonClick()
    {
        _pauseButtom.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    private void OnSettingsButtonClick()
    {
        Time.timeScale = 0;
        _settingsScreen.gameObject.SetActive(true);
    }

    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene(_menuScreenNumber);
    }
}