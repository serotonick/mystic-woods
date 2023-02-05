using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FleeTarget : MonoBehaviour
{
    float distanceToCat;
    float directionOfCat;
    float directionToTarget;
    float searchRadius = 1;
    public SlimeGFX slimeGFX;
    SlimeBehavior slimeBehavior;
    GameObject cat;
    GameObject slime;
    IAstarAI ai;
    GameObject fleeCursor;
    AIPath aiPath;
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        slimeBehavior = GetComponentInParent<SlimeBehavior>();
        cat = GameObject.FindGameObjectWithTag("Cat");
        slime = GameObject.FindGameObjectWithTag("Slime");
        fleeCursor = GameObject.Find("Flee Target");
        ai = GetComponentInParent<IAstarAI>();
        aiPath = GetComponentInParent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {   
        distanceToCat = Vector2.Distance(slime.transform.position, cat.transform.position);
        directionOfCat = Vector2.Angle(slime.transform.position, cat.transform.position);
        directionToTarget = Vector2.Angle(slime.transform.position, fleeCursor.transform.position);

        PickFleePath();
    }
    public void PickFleePath () 
    {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (distanceToCat < slimeBehavior.fleeRadius) 
        {
            if(directionToTarget < directionOfCat + 105 || directionToTarget > directionOfCat + 75)
            {
                if(!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath))
                {
                transform.localPosition = PickRandomPoint();
                aiPath.canMove = true;
                animator.SetBool("isMoving", true);
                   
             } else 
            {
                PickRandomPoint();
            }
        }
    
        }
    }
    
    Vector3 PickRandomPoint () 
    {
        var point = Random.insideUnitSphere * searchRadius;
        point.y = 0;
        point += ai.position;
        return point;
    }
}
