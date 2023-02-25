using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button _playButtom;
    [SerializeField] private Button _levelsButtom;
    [SerializeField] private Button _settingsButtom;
    [SerializeField] private Button _exitButtom;
    [SerializeField] private LevelsScreen _levelsScreen;
    [SerializeField] private SettingsScreen _settingsScreen;

    private void OnEnable()
    {
        _playButtom.onClick.AddListener(OnPlayButtonClick);
        _levelsButtom.onClick.AddListener(OnLevelsButtonClick);
        _settingsButtom.onClick.AddListener(OnSettingsButtonClick);
        _exitButtom.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _playButtom.onClick.RemoveListener(OnPlayButtonClick);
        _levelsButtom.onClick.RemoveListener(OnLevelsButtonClick);
        _settingsButtom.onClick.RemoveListener(OnSettingsButtonClick);
        _exitButtom.onClick.AddListener(OnExitButtonClick);
    }

    public void OnPlayButtonClick()
    {
        _levelsScreen.gameObject.SetActive(true);
    }

    public void OnLevelsButtonClick()
    {
        _levelsScreen.gameObject.SetActive(true);
    }

    public void OnSettingsButtonClick()
    {
        _settingsScreen.gameObject.SetActive(true);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}