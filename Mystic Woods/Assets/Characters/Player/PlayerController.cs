using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Takes and handles input and movement for a player character

public class PlayerController : MonoBehaviour
{
    private LayerMask obstacles;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;

    Vector2 movementInput;
    Vector2 movementDirection;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rb;

    public Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            /*animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);*/
            animator.SetBool("isMoving", true);
            
        }
        //If movement input is not 0, try to move
        if (canMove == true && movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0));

            }
            if (!success)
            {
                success = TryMove(new Vector2(0, movementInput.y));
            }
            


        }else
            {
                animator.SetBool("isMoving", false);
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

        UpdateAnimation();
    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {   
            //Check for potantial collisions
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                //If count of collisions is zero, move
                rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * direction);
                
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }



    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
        movementDirection = movementInput;
    }
    //Call appropriate animation for walk and idle
    void UpdateAnimation()
    {
        
            /*if (movementInput != Vector2.zero)
            {
                animator.Play("movementTree");
            }
            else
            {
                animator.Play("idleTree");
            }*/
        
    }
    //Call animation for sword attack
    /*void OnFire()
    {
        animator.Play("Player_Attack");

    }
    public void LockMovement()
    {
        canMove = false;

    }
    public void SwordAttack()
    {
        LockMovement();
        if (movementInput.x <= -0.01)
        {
            swordAttack.AttackLeft();

        }
        if (movementInput.x >= 0.01)
        {
            swordAttack.AttackRight();
        }
        if (movementInput.y >= 0.01)
        {
            swordAttack.AttackUp();
        }
        if (movementInput.y <= -0.01)
        {
            swordAttack.AttackDown();
        }
    }
    public void UnlockMovement()
    {
        canMove = true;
        swordAttack.StopAttack();
    }*/

}

