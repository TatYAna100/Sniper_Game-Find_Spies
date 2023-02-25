using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountEnemies : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _numberEnemies;

    private void OnEnable()
    {
        _player.CountEnemiesChanged += OnCountEnemiesChanged;
    }

    private void OnDisable()
    {
        _player.CountEnemiesChanged -= OnCountEnemiesChanged;
    }

    private void OnCountEnemiesChanged(int countEnemies)
    {
        _numberEnemies.text = countEnemies.ToString();
    }
}
