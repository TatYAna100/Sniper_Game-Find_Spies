using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodys;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _pushForce;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _hitText;

    private void Start()
    {
        for (int i = 0; i < _rigidbodys.Length; i++)
        {
            _rigidbodys[i].isKinematic = true;
        }
    }

    public void MakePhysical()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        for (int i = 0; i < _rigidbodys.Length; i++)
        {
            _rigidbodys[i].isKinematic = false;
        }

        yield return new WaitForSeconds(0.1f);
        _rigidbody.AddForce(Vector3.one * _pushForce, ForceMode.VelocityChange);
        _player.ApplyDamage();
        _hitText.SetActive(true);
        yield return new WaitForSeconds(3f);
        _hitText.SetActive(false);
        Destroy(gameObject);
    }
}