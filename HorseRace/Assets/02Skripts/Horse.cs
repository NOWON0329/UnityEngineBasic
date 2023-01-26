using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public bool doMove;
    [SerializeField]
    private float speed;
    [SerializeField]
    [Range(0f, 1f)]
    private float stability;

    /// <summary>
    /// 고정 프레임당 한번 호출
    /// 거리변화량 = 속도 * 시간 변화량 (Vector3.forward * randomSpeed * Time.fixedDeltaTime)
    /// </summary>
    private void FixedUpdate()
    {
        if(doMove)
        {
            Move();
        }
    }

    public void Move()
    {
        float randomSpeed = speed * Random.Range(stability, 1.0f);
        transform.Translate(Vector3.back * randomSpeed * Time.fixedDeltaTime);
    }
}
