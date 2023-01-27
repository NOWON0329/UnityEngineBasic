using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//말들 따라가게 할 카메라
public class TargetFollowCamera : MonoBehaviour
{ 
    //타겟이 있을때만 활성화
    public Transform target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
            gameObject.SetActive(value != null);
        }
    }

    private Transform _target;
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private Vector3 _angle;

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(_angle);
    }

    private void LateUpdate()
    {
        if (_target == null)
            return;

        transform.position = _target.position + _offset;
    }
}
