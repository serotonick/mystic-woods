using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SlimeGFX : MonoBehaviour
{   
    AIPath aiPath;
    //private Vector3 desiredVelocity;
    int idleCount;
    int jumpCount;
    public int maxJump;
    public int maxIdle;
    Animator animator;
    SlimeBehavior slimeBehavior;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        slimeBehavior = GetComponentInParent<SlimeBehavior>();
        aiPath = GetComponentInParent<AIPath>();
        jumpCount = 0;
        idleCount = 0;
        aiPath.canMove = false;
        animator.SetBool("isMoving", false);
    }

    // Update is called once per frame
    void Update()

    {
        SpriteFlip();
        if(!slimeBehavior.wantsToWander && slimeBehavior.followingShepherd)
        {
            SetBoolMoving();
            aiPath.maxSpeed = .2f;
            }
    }

    void SetBoolMoving()
    {
        if(aiPath.desiredVelocity.x != 0 || aiPath.desiredVelocity.y != 0){
            animator.SetBool("isMoving", true);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }
    }
    void SpriteFlip()
    {    
        if(aiPath.desiredVelocity.x >= 0.01f)
    {
            transform.localScale = new Vector3(1f, 1f, 1f);
    } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }        
    }
    void Jiggle()
    {
        
    }    
    public void IdleCounter()
    {   
        if(slimeBehavior.wantsToWander)
        {
            idleCount += 1;
            if (idleCount >= maxIdle)
        {
                aiPath.canMove = true;
                animator.SetBool("isMoving", true);
                idleCount = 0;
                aiPath.maxSpeed = .15f;
                return;
        }
            return;
        }
    }

    public void JumpCounter()
    {   
        if(slimeBehavior.wantsToWander)
        {
            jumpCount += 1;
            if (jumpCount >= maxJump)
        {
                jumpCount = 0;
                aiPath.canMove = false;
                animator.SetBool("isMoving", false);
                aiPath.maxSpeed = .15f;
                return;
        }
            return;
        }
    }
}


