using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterFire : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _reloadTime = 0.2f;
    private float _reloadTImer;

    private void Update()
    {
        if(_reloadTImer <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //todo -> ÃÑ¾Ë »ý¼º
                Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
                _reloadTImer = _reloadTime;
            }
        }
        else
        {
            _reloadTImer -= Time.deltaTime;
        }
    }
}
