using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement2D : MonoBehaviour {
    public LevelInteractions levelInt;
    public RaycastCollission raycast;
    public Animator _anim;

    public GameObject _player;
    private float _acceleration = 25f;
    private float _speedRuductor = 0.85f;
    private float _maxSpeed = 15f;
    public float _currentSpeed;
    public float _speed = 10f;
    private float _jump;
    private float _jumpStr = 8f;

    public int _maxJumps = 1;
    public int _jumpAmnt = 1;

    private Rigidbody2D rby;
    private SpriteRenderer _rendy;

    private Vector3 _startPos;
    private Vector3 _currentPos;
    private bool _isWalking;
    public bool _isJumping;
   
    void Start () {
        rby = gameObject.GetComponent<Rigidbody2D>();
        _rendy = gameObject.GetComponent<SpriteRenderer>();
        levelInt = this.GetComponent<LevelInteractions>();
        _anim.GetComponent<Animator>();
        raycast = this.GetComponent<RaycastCollission>();

        _startPos = _player.transform.position;
    }

    void Update()
    {
        _anim.SetBool("isWalking", _isWalking);
        _anim.SetBool("isJumping", _isJumping);

        if(_player.transform.position.y <= 0)
        {
            _player.transform.position = _startPos;
        }
       
        if (_jumpAmnt > 0 && raycast.collisionDown == true || _jumpAmnt > 0 && levelInt.walled == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _jumpAmnt--;
                if (levelInt._leftHit == true && raycast.collisionDown == false)
                {
                    rby.velocity += new Vector2(6, _jumpStr);
                    _rendy.flipX = false;
                }
                else if (levelInt._rightHit == true && raycast.collisionDown == false) 
                {
                    rby.velocity += new Vector2(-6, _jumpStr);
                    _rendy.flipX = true;
                }
                else
                {
                    rby.velocity = new Vector2(rby.velocity.x, _jumpStr);
                }
                levelInt._sticking = false;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                levelInt._sticking = false;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _isWalking = true;
                // _currentSpeed = 1;

                // IncreaseSpeed();
                // rby.position += new Vector2(_currentSpeed,0);
            }
            else
            {
                _isWalking = false;
            }
        }
        if(raycast.collisionDown == true && Input.GetKey(KeyCode.W))
        {
            _isJumping = true;
        }
        else
        {
            _isJumping = false;
        }
    }

    void FixedUpdate()
    {
      if(raycast.collisionDown == true)
        {
            MoveInput();
            
        }
        else
        {
            
            return;
        }

      if(_isWalking == false && raycast.collisionDown == true)
        {
            rby.velocity =  new Vector2(rby.velocity.x * _speedRuductor,rby.velocity.y);
            
        }
    }

    void MoveInput()
    {
        _currentSpeed = rby.velocity.x;
        float x = Input.GetAxis("Horizontal");

        if (x < -0.1f)
        {
            if (_currentSpeed > -this._maxSpeed)
            {
                rby.AddForce(new Vector2(-this._acceleration, 0.0f));
            }
            else if (-_currentSpeed <= _maxSpeed)
            {
                rby.AddForce(new Vector2(-this._maxSpeed, rby.velocity.y));
            }
        }
        else if (x > 0.1f)
        {
            if (_currentSpeed < this._maxSpeed)
            {
                rby.AddForce(new Vector2(this._acceleration, 0.0f));
            }
            else if (-_currentSpeed >= _maxSpeed)
            {
                rby.AddForce(new Vector2(this._maxSpeed, rby.velocity.y));
            }
        }

        if (x < 0)
        {
            _rendy.flipX = true;
        }
        else if(x > 0)
        {
            _rendy.flipX = false;
        }
    
    }
}