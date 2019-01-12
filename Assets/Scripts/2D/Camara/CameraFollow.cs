using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform _target;

    private float _followSpeed = 10f;
    private Vector3 _offset = new Vector3(0, 1.5f, -10f);


    void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 followingPosition = Vector3.Slerp(transform.position, desiredPosition, _followSpeed * Time.deltaTime);
        transform.position = followingPosition;
    }
}
