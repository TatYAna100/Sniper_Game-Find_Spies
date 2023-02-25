using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammunitionCount;
    [SerializeField] private Weapon _weapon;

    private void OnEnable()
    {
        _weapon.AmmunitionCountChanged += OnAmmunitionCountChanged;
    }

    private void OnDisable()
    {
        _weapon.AmmunitionCountChanged -= OnAmmunitionCountChanged;
    }

    private void OnAmmunitionCountChanged(int ammunitionCount)
    {
        _ammunitionCount.text = ammunitionCount.ToString();
    }
}