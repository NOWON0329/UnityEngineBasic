using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target { get; set; }
    [SerializeField] private float _speed = 2f;
    private Vector3 _dir = Vector3.forward;
    private Transform _tr;

    private void Awake()
    {
        _tr = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if(target != null && target.position.z < _tr.position.z - 3)
        {
            transform.LookAt(target);
        }
        _tr.transform.Translate(_dir * _speed * Time.fixedDeltaTime, Space.Self);
    }
}
