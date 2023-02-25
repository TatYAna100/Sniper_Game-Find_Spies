using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsScreen : MonoBehaviour
{
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _level3Button;
    [SerializeField] private Button _level4Button;
    [SerializeField] private Button _level5Button;
    [SerializeField] private Button _level6Button;
    [SerializeField] private Button _level7Button;
    [SerializeField] private Button _level8Button;
    [SerializeField] private Button _level9Button;
    [SerializeField] private Button _exitButtom;
    [SerializeField] private MenuScreen _menuScreen;

    private int _levelComplete;

    private void OnEnable()
    {
        _exitButtom.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _exitButtom.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");
        _level2Button.interactable = false;
        _level3Button.interactable = false;
        _level4Button.interactable = false;
        _level5Button.interactable = false;
        _level6Button.interactable = false;
        _level7Button.interactable = false;
        _level8Button.interactable = false;
        _level9Button.interactable = false;

        switch (_levelComplete)
        {
            case 1:
                _level2Button.interactable = true;
                break;
            case 2:
                _level2Button.interactable = true;
                _level3Button.interactable = true;
                _level4Button.interactable = true;
                _level5Button.interactable = true;
                _level6Button.interactable = true;
                _level7Button.interactable = true;
                _level8Button.interactable = true;
                _level9Button.interactable = true;
                break;
        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
        this.gameObject.SetActive(false);
        _menuScreen.gameObject.SetActive(false);
    }

    private void OnExitButtonClick()
    {
        this.gameObject.SetActive(false);
    }

    //private void Reset()
    //{
    //    _level2Button.interactable = false;
    //    _level3Button.interactable = false;
    //    _level4Button.interactable = false;
    //    _level5Button.interactable = false;
    //    _level6Button.interactable = false;
    //    _level7Button.interactable = false;
    //    _level8Button.interactable = false;
    //    _level9Button.interactable = false;
    //    PlayerPrefs.DeleteAll();
    //}
}