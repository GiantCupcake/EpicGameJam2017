﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private GameObject interactableObject;
	private UnityEngine.UI.Text textInteract;
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
    private int pv = 50;
    private bool isGrounded = false;
    private bool jumpStarted = false;
    public Transform groundCheck;
    public LayerMask whatisground;
    float groundRadius = 0.1f;
    private List<int> keyBuffer;

	public Animator animator;
	private SpriteRenderer spriteRenderer;
    private int bufferTime = 30;
    private int bufferCounter = 0;

    void Start () {
        //get the Rigidbody2D component
        rig = this.transform.GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer> ();

		textInteract = this.GetComponentInChildren<UnityEngine.UI.Text> ();
		textInteract.enabled = false;
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
		if (pv <= 0) {
			gameOver ();
			return true;
		}
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

	void gameOver(){
		Debug.Log ("GameEnded");
	}

    void HandleControl()
    {
        if (Input.GetKey(KeyCode.A))
        {
			animator.SetBool("idle", false);
			spriteRenderer.flipX = true;
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
			animator.SetBool("idle", false);
			spriteRenderer.flipX = false;
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
		else
			animator.SetBool("idle", true);
        if (Input.GetKeyDown(KeyCode.W))
        {
            /*
             *  saut fixe
             */
            if (isGrounded)
                rig.AddForce(new Vector2(this.rig.velocity.x, jumpForce));
        }

		if (Input.GetKeyDown(KeyCode.Return))
		{
			/*
             *  Interaction avec l'interactable
             */
			if (interactableObject != null)
			{
				interactableObject.SendMessage("Interact");
			}
		}
    }

	public void SetInteractableObject(GameObject interactable){
		this.interactableObject = interactable;
		textInteract.enabled = true;
	}

	public void ClearInteractableObject(){
		this.interactableObject = null;
		textInteract.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy")
			getWrecked (other.transform.position);
	}

	void OnCollisionEnter2D(Collider2D other){

	}

	public void getWrecked(Vector3 enemyPos){
		takeDamage (5);
		rig.AddForce ((transform.position - enemyPos) * 300);
	}
}
