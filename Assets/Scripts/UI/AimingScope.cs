using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimingScope : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private ScopeWindow _scopeWindow;
    [SerializeField] private float _scopedFieldOfView;
    [SerializeField] private Button _scopeWindowButton;
    [SerializeField] private Button _returnButton;

    private float _currentFieldOfView;

    private void OnEnable()
    {
        _scopeWindowButton.onClick.AddListener(OnScopeWindowButtonClick);
        _returnButton.onClick.AddListener(OnReturnButtonClick);
    }

    private void OnDisable()
    {
        _scopeWindowButton.onClick.RemoveListener(OnScopeWindowButtonClick);
        _returnButton.onClick.RemoveListener(OnReturnButtonClick);
    }

    private void OnScopeWindowButtonClick()
    {
        _scopeWindowButton.gameObject.SetActive(false);
        _returnButton.gameObject.SetActive(true);
        _currentFieldOfView = _mainCamera.fieldOfView;
        _mainCamera.fieldOfView = _scopedFieldOfView;
        _scopeWindow.gameObject.SetActive(true);
    }

    public void OnReturnButtonClick()
    {
        _scopeWindow.gameObject.SetActive(false);
        _mainCamera.fieldOfView = _currentFieldOfView;
        _returnButton.gameObject.SetActive(false);
        _scopeWindowButton.gameObject.SetActive(true);
    }
}