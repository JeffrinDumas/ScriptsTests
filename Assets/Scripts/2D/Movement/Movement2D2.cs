using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D2 : MonoBehaviour {
    [SerializeField]
    private GameObject _player2;

    private float _maxSpeed;
    private float _currentSpeed = 10f;
    
    void Start ()
    {
		
	}
	
	void Update ()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x, y) * Time.deltaTime * _currentSpeed);
    }
}
