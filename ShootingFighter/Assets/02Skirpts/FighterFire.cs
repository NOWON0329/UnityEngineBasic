using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FighterFire : MonoBehaviour
{
    public static FighterFire instance;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Transform[] _firePoint;
    [SerializeField] private Transform _bombPoint;
    [SerializeField] private float _bulletReloadTime = 0.2f;
    [SerializeField] private float _bombReloadTime = 1f;
    private float _bulletReloadTimer;
    private float _bombReloadTimer;
    public int bombNum
    {
        get
        {
            return _bombNum;
        }
        set
        {
            if(value > _bombNumMax)
                value = _bombNumMax;

            if (_bombNum == value)
                return;

            _bombNum = value;
            OnBombNumChanged?.Invoke(value);
        }
    }
    private int _bombNum;
    [SerializeField] int _bombNumInit = 3;
    [SerializeField] int _bombNumMax = 7;
    public event Action<int> OnBombNumChanged;

    private void Awake()
    {
        instance = this;
        bombNum = _bombNumInit;   
    }

    private void Update()
    {
        FireBullet();
        FireBomb();
    }
    private void FireBullet()
    {
        if (_bulletReloadTimer <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //todo -> �Ѿ� ����
                for(int i = 0; i<_firePoint.Length; i++)
                {
                    Instantiate(_bulletPrefab, _firePoint[i].position, Quaternion.identity);
                }
                _bulletReloadTimer = _bulletReloadTime;
            }
        }
        else
        {
            _bulletReloadTimer -= Time.deltaTime;
        }
    }
    private void FireBomb()
    {
        if (_bombNum > 0)
        {
            if (_bombReloadTimer <= 0)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    //todo -> �Ѿ� ����
                    Instantiate(_bombPrefab, _bombPoint.position, Quaternion.identity);
                    bombNum--;
                    _bombReloadTimer = _bombReloadTime;
                }
            }
            else
            {
                _bombReloadTimer -= Time.deltaTime;
            }
        }
    }
}
