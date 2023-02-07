using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FleeTarget : MonoBehaviour
{
    float distanceToCat;
    float directionOfCat;
    float directionToTarget;
    float searchRadius = 5;
    float ignoreRadius = 5;
    SlimeBehavior slimeBehavior;
    public AIDestinationSetter aiDestinationSetter;
    GameObject cat;
    GameObject slime;
    GameObject fleeCursor;
    IAstarAI ai;
    AIPath aiPath;
    public Animator animator;
    float catSlimeAngle;
    Vector2 catSlimeV2;
    Vector2 targetSlimeV2;
    float targetSlimeAngle;
    public bool fleeing;
    Vector2 position;


    // Start is called before the first frame update
    void Start()
    {
        slimeBehavior = GetComponentInParent<SlimeBehavior>();
        cat = GameObject.FindGameObjectWithTag("Cat");
        slime = GameObject.FindGameObjectWithTag("Slime");
        fleeCursor = GameObject.Find("Flee Target");
        ai = GetComponentInParent<IAstarAI>();
        aiPath = GetComponentInParent<AIPath>();
        aiDestinationSetter = GetComponentInParent<AIDestinationSetter>();
        position = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToCat = Vector2.Distance(slime.transform.position, cat.transform.position);
        directionOfCat = Vector2.Angle(slime.transform.position, cat.transform.position);
        directionToTarget = Vector2.Angle(slime.transform.position, fleeCursor.transform.position);
        FleeFromCat();
        catSlimeAngle = Mathf.Atan2(catSlimeV2.y, catSlimeV2.x) * Mathf.Rad2Deg;
        catSlimeV2 = new Vector2(cat.transform.position.x - slime.transform.position.x, cat.transform.position.y - slime.transform.position.y);
        targetSlimeAngle = Mathf.Atan2(targetSlimeV2.y, targetSlimeV2.x) * Mathf.Rad2Deg;
        targetSlimeV2 = new Vector2(transform.localPosition.x - slime.transform.position.x, transform.localPosition.y- slime.transform.position.y);
        

    }
    public void FleeFromCat()
    {
        aiPath.canMove = true;
        
        if ((distanceToCat < slimeBehavior.fleeRadius) && !slimeBehavior.followingShepherd)
        {
            fleeing = true;

        }            
        if (fleeing)
            {
                slimeBehavior.wantsToWander = false;
                PickFleeDirection();
                SetBoolMoving();
                
            }
        if (distanceToCat > ignoreRadius)
        {
            fleeing = false;
            slimeBehavior.wantsToWander = true;
            aiPath.maxSpeed = 0.1f;
        }


        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        /*if (distanceToCat < slimeBehavior.fleeRadius)
        {//
            if (directionToTarget > directionOfCat + 105 || directionToTarget < directionOfCat + 75)
            {
                if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath))
                {
                    transform.localPosition = PickRandomPoint();
                    aiPath.canMove = true;
                    animator.SetBool("isMoving", true);
                    aiPath.maxSpeed = 0.3f;

                }
            }
            else
            {
                PickRandomPoint();
            }
        }*/


    }

    void PickFleeDirection()
    {
        transform.localPosition = position;
        if (targetSlimeV2.x * catSlimeV2.x < 0)
                {
                    if (targetSlimeV2.y * catSlimeV2.y < 0)
                    {
                        
                        if(!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath))
                            {   
                                aiPath.maxSpeed = 0.3f;
                                aiPath.canMove = true;
                                aiDestinationSetter.target = transform;
                                ai.SearchPath();
                                }
                        
                    }
                    else
                    {
                        position = PickRandomPoint();
                        
                    }
                }
                else
                {
                    position = PickRandomPoint();
                    
                }
    }

    Vector3 PickRandomPoint()
    {
        var point = Random.insideUnitSphere * searchRadius;
        point += ai.position;
        return point;
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
}

