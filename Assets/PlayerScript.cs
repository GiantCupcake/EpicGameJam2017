﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    //Movement
    private float hSpeed = 0.0f;
    private float vSpeed = 0.0f;
    private float maxHVelocity = 5.0f;
    private float hAccel = 30.0f;
    private float jumpForce = 300.0f;
    private float jumpTimer = 0.0f;
    private float maxJumpTimer = 60.0f;
    private Rigidbody2D rig;
    //Stats
    private int pv;
    private bool isGrounded = false;
    private bool jumpStarted = false;
    public Transform groundCheck;
    public LayerMask whatisground;
    float groundRadius = 0.1f;
    private List<int> keyBuffer;

    private int bufferTime = 30;
    private int bufferCounter = 0;

    void Start () {
        //get the Rigidbody2D component
        rig = this.transform.GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update () {
        updateBuffer();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatisground);
        HandleControl();
	}

    public bool takeDamage(int _d)
    {
        this.pv -= _d;
        if (_d < 0)
            return true;
        else
            return false;
    }
    void updateBuffer()
    {
        bufferCounter++;
        if (bufferCounter == bufferTime)
        {
            bufferCounter = 0;

        }
    }
    void HandleControl()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (rig.velocity.x > -maxHVelocity)
            {
                if (isGrounded)
                {
                    rig.AddForce(new Vector2(-hAccel, 0.0f));
                }
                else
                {
                    rig.AddForce(new Vector2(-hAccel/2, 0.0f));
                }
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (rig.velocity.x < maxHVelocity)
            {
                if (isGrounded)
                {
                    rig.AddForce(new Vector2(hAccel, 0.0f));
                }
                else
                {
                    rig.AddForce(new Vector2(hAccel/2, 0.0f));
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            /*
             *  saut fixe
             */
            if (isGrounded)
            {
                rig.AddForce(new Vector2(this.rig.velocity.x, jumpForce));
            }
        }
    }
}