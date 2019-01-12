using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour {
    private float _slideSpeed = 2f;
    private Vector3 _offset = new Vector3(0, 5.5f, 0);

    public void SlideDoor()
    { 
        Vector3 desiredPosition = transform.position + _offset;
        Vector3 followingPosition = Vector3.Lerp(transform.position, desiredPosition, _slideSpeed * Time.deltaTime);
        transform.position = followingPosition;
    }
}

