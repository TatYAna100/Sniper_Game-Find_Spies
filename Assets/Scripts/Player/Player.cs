using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _secondsBetweenShoot;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private ScopeWindow _scopeWindow;
    [SerializeField] private LevelEndScreen _levelEndScreen;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _star;
    [SerializeField] private TimeCount _timeCount;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private GameObject _starDone;

    private const string _shoot = "Shoot";
    private float _lastShootTime;
    private Animator _animator;
    private int _countEnemies = 10;

    public event UnityAction<int> CountEnemiesChanged;
    public event UnityAction LevelEnd;

    private void Start()
    {
        CountEnemiesChanged?.Invoke(_countEnemies);
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ApplyShooting();
    }

    private void ApplyShooting()
    {
        if (_lastShootTime <= 0)
        {
            if (Input.GetMouseButtonDown(0) && _scopeWindow.isActiveAndEnabled)
            {
                _weapon.Shoot();
                _animator.SetTrigger(_shoot);
                _lastShootTime = _secondsBetweenShoot;
            }
        }

        _lastShootTime -= Time.deltaTime;
    }

    public void ApplyDamage()
    {
        _countEnemies--;
        CountEnemiesChanged?.Invoke(_countEnemies);

        if (_countEnemies == 0 && _gameOverScreen.isActiveAndEnabled == false)
        {
            LevelEnd?.Invoke();
            _levelEndScreen.gameObject.SetActive(true);
            _starDone.gameObject.SetActive(true);
            _audioSource.PlayOneShot(_star);
        }
    }
}