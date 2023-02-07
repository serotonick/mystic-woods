using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class SlimeBehavior : MonoBehaviour
{
    IAstarAI ai;
    AIPath aiPath;
    WanderingDestinationSetter wanderDestinationSetter;
    AIDestinationSetter fightOrFlight;
    Transform followTarget;
    GameObject slime;
    GameObject shepherd;
    GameObject cat;
    GameObject fleeTarget;
    Animator animator;
    int idleCount;
    int jumpCount;
    public int maxJump;
    public int maxIdle;
    float distanceToShepherd;
    float distanceToCat;
    public float followRadius;
    public float fleeRadius;
    public bool wantsToWander;
    public bool followingShepherd;
    float directionOfCat;
    FleeTarget fleeTargetScript;

    void Start()
    {
        //Get some Components
        animator = GetComponent<Animator>();
        ai = GetComponent<IAstarAI>();
        aiPath = GetComponent<AIPath>();
        wanderDestinationSetter = GetComponent<WanderingDestinationSetter>();
        fightOrFlight = GetComponent<AIDestinationSetter>();
        //Get some GameObjects
        shepherd = GameObject.Find("Shepherd");
        slime = GameObject.Find("Slime");
        cat = GameObject.Find("Cat");
        fleeTarget = GameObject.Find("Flee Target");
        animator.SetBool("isMoving", false);
        fleeTargetScript = GetComponentInChildren<FleeTarget>();
        //Reset Variables
        followTarget = null;
        followingShepherd = false;
        wantsToWander = true;
        aiPath.canMove = false;
        jumpCount = 0;
        maxJump = 1;
        idleCount = 0;
        maxIdle = 5;

    }
    void Update()
    {
        SpriteFlip();
        if (!wantsToWander && followingShepherd)
        {
            SetBoolMoving();
            aiPath.maxSpeed = .2f;
        }
        ComeToShepherd();
        if(wantsToWander){wanderDestinationSetter.PickWanderPath();}

    }
    void SetBoolMoving()
    {
        if (aiPath.desiredVelocity.x != 0 || aiPath.desiredVelocity.y != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    void SpriteFlip()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    public void ComeToShepherd()
    {
        distanceToShepherd = Vector2.Distance(slime.transform.position, shepherd.transform.position);

        //print(distanceToShepherd);
        if (distanceToShepherd < followRadius)
        {
            fightOrFlight.target = shepherd.transform;
            followingShepherd = true;
            wantsToWander = false;
            aiPath.canMove = true;
            fleeTargetScript.fleeing = false;
        }

    }
    public void IdleCounter()
    {
        if (wantsToWander)
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
        if (wantsToWander)
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

