using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyPrefab;
    [SerializeField] private float _spawnRange = 20;
    [SerializeField] private float _spawnDelay = 0.5f;
    [SerializeField] private Transform _target;
    [SerializeField] private float _targetFollowRate = 0.7f;
    private float _timer;

    private void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        if(_timer <= 0)
        {
            Instantiate(original: _enemyPrefab,
                position: transform.position + new Vector3(Random.Range(-_spawnRange / 2f, +_spawnRange / 2f),0,0),
                rotation : Quaternion.Euler(0, 180, 0)).target = Random.Range(0f, 1f) < 0.7f ? _target : null;

            _timer = _spawnDelay;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
