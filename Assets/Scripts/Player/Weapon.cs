using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Player _player;
    [SerializeField] private AimingScope _aimingScope;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioShot;
    [SerializeField] private AudioClip _audioRecharge;


    private const string _recharge = "Recharge";
    private Animator _animator;
    private int _ammunitionCounte;
    private int _magazine = 4;

    public event UnityAction<int> AmmunitionCountChanged;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _ammunitionCounte = _magazine;
        AmmunitionCountChanged?.Invoke(_ammunitionCounte);
    }

    public void Shoot()
    {
        _audioSource.PlayOneShot(_audioShot);
        _ammunitionCounte--;
        AmmunitionCountChanged?.Invoke(_ammunitionCounte);

        if (_ammunitionCounte <= 0)
        {
            StartCoroutine(Reload());
        }
        else
        {
            Instantiate(_bulletTemplate, _shootPoint.position, _shootPoint.rotation);
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.3f);
        _aimingScope.OnReturnButtonClick();
        _audioSource.PlayOneShot(_audioRecharge);
        _animator.SetTrigger(_recharge);
        yield return new WaitForSeconds(0.6f);
        _ammunitionCounte = _magazine;
        AmmunitionCountChanged?.Invoke(_ammunitionCounte);
    }
}