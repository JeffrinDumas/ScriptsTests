using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {
    public LevelInteractions levelInt;
    public Animator _anim;
      
    public GameObject _player;

    private float _speedRuductor = 0.1f;
    public float _currentSpeed;
    public float _speed = 10f;

    private float _jump;
    private float _jumpStr = 8f;

    public int _maxJumps = 1;
    public int _jumpAmnt = 1;


    private Rigidbody2D rby;

    private Vector3 _currentPos;
    public bool isWalking;
  

    // Use this for initialization
    void Start()
    {
        
        rby = gameObject.GetComponent<Rigidbody2D>();
        levelInt = this.GetComponent<LevelInteractions>();
        _anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentSpeed = rby.velocity.x;
        _anim.SetBool("isWalking", isWalking);

            if(_jumpAmnt > 0 && levelInt.grounded == true || _jumpAmnt > 0 && levelInt.walled == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                
                    _jumpAmnt--;
                    if(levelInt._leftHit == true)
                    {
                        rby.velocity += new Vector2(6, _jumpStr);
                    }
                    else if(levelInt._rightHit == true)
                    {
                        rby.velocity += new Vector2(-6, _jumpStr);
                    }
                    else
                    {
                        rby.velocity = new Vector2(rby.velocity.x, _jumpStr);
                    }
                    levelInt._sticking = false;
                }
                else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    levelInt._sticking = false;
                
                }
                
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    isWalking = true;
                   // _currentSpeed = 1;

                   // IncreaseSpeed();
                   // rby.position += new Vector2(_currentSpeed,0);
                }
                else
                {
                    isWalking = false;
                }

            if(_currentSpeed > 1) { 
                 if(isWalking == false)
                 {
                    _currentSpeed = _currentSpeed * _speedRuductor;                              
                 }
                 else
                 {
                     return;
                 }
            }
           
        }
	}

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");


        rby.AddForce((Vector2.right * _speed) * x);


    }


}
