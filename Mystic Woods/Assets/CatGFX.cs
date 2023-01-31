using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatGFX : MonoBehaviour
{
    Vector2 movementInput;
    Vector2 movementDirection;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public Rigidbody2D rb;

    PlayerController playerController;


    void Start(){
        animator = GetComponent<Animator>();

            }
    void FixedUpdate()
    {
                if(rb.velocity.x >= 0.01f)
    {
            transform.localScale = new Vector3(1f, 1f, 1f);
    } else if (rb.velocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    void Update()
    {
        if(rb.velocity != Vector2.zero){
            animator.SetBool("isMoving", true);
        } else{
            animator.SetBool("isMoving", false);
        }
           
           
     } 

        /*if(movementDirection.x != 0 || movementDirection.y != 0){
            animator.SetBool("isMoving", true);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }*/
        
        
        /*if (movementInput != Vector2.zero)
        {
            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);
        }

        //set direction of sprite to movement direction
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        UpdateAnimation();*/
    

    /*void UpdateAnimation()
    {
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                animator.Play("Player_Moving");
            }
            else
            {
                animator.Play("Player_Idle");
            }
        }
    }*/
}
