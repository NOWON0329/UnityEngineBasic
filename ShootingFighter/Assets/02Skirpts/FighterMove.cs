using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 전투기 이동 제어
/// todo -> 상하좌우키를 통해 전투기를 상하좌우로 이동시킬 수 있는 스크립트 작성
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
