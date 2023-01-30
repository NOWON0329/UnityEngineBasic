using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// ������ �̵� ����
/// todo -> �����¿�Ű�� ���� �����⸦ �����¿�� �̵���ų �� �ִ� ��ũ��Ʈ �ۼ�
/// </summary>
public class FighterMove : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        CheckInput();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void CheckInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        transform.Translate(new Vector3(_horizontal, 0, _vertical) * _speed * Time.fixedDeltaTime);
    }
}
