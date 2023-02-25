using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private const string _russian = "Russian";
    private const string _english = "English";
    private const string _turkish = "Turkish";

    public void Russian()
    {
        PlayerPrefs.SetString("Language", _russian);
    }

    public void English()
    {
        PlayerPrefs.SetString("Language", _english);
    }

    public void Turkish()
    {
        PlayerPrefs.SetString("Language", _turkish);
    }
}