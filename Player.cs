using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator unicornAnim;
    private int jumpCounter = 1;
    private bool isGrounded;
    private GameObject audioMaster;

    public bool dead, moveToStart = false;
    public int jumpsNumbers;
    public float jumpForce, checkRadius, speed;
    public Transform feetPos, startPos;
    public LayerMask ground;
    public AudioClip jumpSound, coinSound, boostSound; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        unicornAnim = GetComponent<Animator>();
        audioMaster = GameObject.FindGameObjectWithTag("AudioMaster");
    }

    private void FixedUpdate()
    {
        //unicorn will be on the ground, then ground (ground layer) is IN radius of circle (chackRadius), which placed by it's center on unicorns feets (feetPos) 
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, ground);        //returns true or false

        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && dead == false)      //allows to jump if not dead
        {
            if (isGrounded)     //allows to jump if or grounded and 0 multi jump counter
            {
                Jump();
                jumpCounter = 1;
            }
            else if (jumpCounter < jumpsNumbers)      //allows to jump in air if multi jumps works
            {
                Jump();
                jumpCounter++;
            }
        }

        switch (isGrounded)     //check when unicorn on ground or not
        {
            case true:
                unicornAnim.SetBool("inAir", false);        //unicorn in air 
                break;

            case false:
                unicornAnim.SetBool("inAir", true);     //unicorn not in air
                break;
        }

        if (transform.position.x < startPos.position.x)
        {
            if (moveToStart == true && dead == false)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else
        {
            moveToStart = false;
        }
    }
   
    public void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        audioMaster.GetComponent<AudioMaster>().PlaySound("jumpSound");
    }
}
