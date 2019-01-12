using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timers : MonoBehaviour {
    public LevelInteractions levelInt;
    public NewMovement2D movement;


    private GameObject player;
   

    private GameObject _playerInt;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<NewMovement2D>();

        levelInt = player.GetComponent<LevelInteractions>();
       
    }

    public IEnumerator StickAndGlide()
    {
        movement._player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.4f);
        levelInt._sticking = false;
    }

    public IEnumerator JumpWindow()
    {
        yield return new WaitForSeconds(0.15f);
        levelInt.walled = false;
    }

    public IEnumerator DactivateBool()
    {
        yield return new WaitForSeconds(0.1f);
        levelInt._leftHit = false;
        levelInt._rightHit = false;
    }
}
