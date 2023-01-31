using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ���ư��ٰ� Ʈ���ŵǸ� �ı��Ǵ� �Ѿ�
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Vector3 _dir = Vector3.forward;
    private Transform _tr;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private int _damage = 20;

    //================================================================
    //                       Private Methods
    //================================================================

    private void Awake()
    {
        _tr = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        transform.Translate(_dir * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(((1<<other.gameObject.layer) & _enemyMask) > 0 )
        {
            other.GetComponent<Enemy>().hp -= _damage;
        }
        Destroy(this.gameObject);
    }
}
