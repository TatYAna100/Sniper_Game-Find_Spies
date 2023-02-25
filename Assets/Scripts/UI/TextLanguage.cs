using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLanguage : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _textRussian;
    [SerializeField] private string _textEnglish;
    [SerializeField] private string _textTurkish;

    private string _language;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _language = PlayerPrefs.GetString("Language");

        if (_language == "" || _language == "English")
        {
            _text.text = _textEnglish;
        }
        else if (_language == "Russian")
        {
            _text.text = _textRussian;
        }
        else if (_language == "Turkish")
        {
            _text.text = _textTurkish;
        }
    }
}