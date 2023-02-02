using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private LayerMask _playerMask;
    private Camera _cam;
    private Transform _tr;
    private Rigidbody _rb;

    private void Awake()
    {
        _tr = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        _cam = Camera.main;
        _rb.velocity = Quaternion.Euler(Vector3.up * Random.Range(0, 360)) * Vector3.back * _speed;
    }

    private void FixedUpdate()
    {
        Vector3 viewPortPoint = _cam.WorldToViewportPoint(_tr.position);

        //¸Ê ¿ÞÂÊ/¿À¸¥ÂÊ °æ°è¿¡ ºÎµúÈú ¶§
        if(viewPortPoint.x < 0 || viewPortPoint.x > 1)
        {
            _rb.velocity = new Vector3(-_rb.velocity.x, -_rb.velocity.y, -_rb.velocity.z);
        }
        //¸Ê À§ÂÊ/¾Æ·§ÂÊ °æ°è¿¡ ºÎµúÈú¶§ xÃà ´ëÄªº¯È¯
        if (viewPortPoint.y < 0 || viewPortPoint.y > 1)
        {
            _rb.velocity = new Vector3(-_rb.velocity.x, -_rb.velocity.y, -_rb.velocity.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if((1<<other.gameObject.layer & _playerMask) > 0)
        {
            FighterFire.instance.bombNum++;
            Destroy(this.gameObject);
        }
    }
}
