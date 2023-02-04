using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SlimeGFX : MonoBehaviour
{   
    AIPath aiPath;
    //private Vector3 desiredVelocity;
    int idleAnimationCount;
    int jumpAnimationCount;
    public int maxAnimationJump;
    public int maxAnimationIdle;
    Animator animator;
    SlimeBehavior slimeBehavior;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        slimeBehavior = GetComponentInParent<SlimeBehavior>();
        aiPath = GetComponentInParent<AIPath>();
    }

    // Update is called once per frame
    void Update()

    {SpriteFlip();}

    /*void FixedUpdate()
    {
        if(aiPath.desiredVelocity.x != 0 || aiPath.desiredVelocity.y != 0){
            animator.SetBool("isMoving", true);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }
    }*/
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
    public void IdleAnimationCounter()
    {
        idleAnimationCount += 1;
        if (idleAnimationCount >= maxAnimationIdle)
        {
            idleAnimationCount = 0;
            slimeBehavior.wantsToWander = true;
            aiPath.canMove = true;
            animator.SetBool("isMoving", true);
            return;
        }
        return;

    }
    public void Jiggle()
    {
        
    }
    public void JumpAnimationCounter()
    {
        jumpAnimationCount += 1;
        if (jumpAnimationCount >= maxAnimationJump)
        {
            jumpAnimationCount = 0;
            slimeBehavior.wantsToWander = true;
            aiPath.canMove = false;
            animator.SetBool("isMoving", false);
            return;
        }
        return;
    }
}


