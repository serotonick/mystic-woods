using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class SlimeBehavior : MonoBehaviour
{   IAstarAI ai;
    WanderingDestinationSetter wanderDestinationSetter;
    AIDestinationSetter followDestinationSetter;
    Transform followTarget;
    GameObject slime;
    GameObject shepherd;
    GameObject cat;
    GameObject fleeTarget;
    SlimeGFX slimeGFX;
    ShepherdGFX shepherdGFX;
    int idleCounter;
    float distanceToShepherd;
    float distanceToCat;
    public float followRadius;
    public float fleeRadius;
    public bool wantsToWander;
    public bool followingShepherd;
    float directionOfCat;

    void Start()
    {   //Reset Variables
        followTarget = null;
        followingShepherd = false;
        wantsToWander = true;
        //Get some Components
        ai = GetComponent<IAstarAI>();
        wanderDestinationSetter = GetComponent<WanderingDestinationSetter>();
        followDestinationSetter = GetComponent<AIDestinationSetter>();
        slimeGFX = GetComponentInChildren<SlimeGFX>();
        shepherd = GameObject.Find("Shepherd");
        slime = GameObject.Find("Slime");
        cat = GameObject.Find("Cat");
        fleeTarget = GameObject.Find("Flee Target");

    }
    void Update()
    {   
        ComeToShepherd();
                
            if(!followingShepherd && wantsToWander)
            {
                wanderDestinationSetter.PickWanderPath();
            }
            if (!ai.pathPending)
            {
            }         
        if(!followingShepherd)
        {
            FleeFromCat();
        }

    }
  public void ComeToShepherd()
  {
        distanceToShepherd = Vector2.Distance(slime.transform.position, shepherd.transform.position);
        
            //print(distanceToShepherd);
        if(distanceToShepherd < followRadius)
        {
            followDestinationSetter.target = shepherd.transform;
            followingShepherd = true;
            wantsToWander = false;
        }
        
  } 
public void FleeFromCat()
{
        distanceToCat = Vector2.Distance(slime.transform.position, cat.transform.position);
        //print(distanceToCat);
        directionOfCat = Vector2.Angle(slime.transform.position, cat.transform.position);
        if(distanceToCat < fleeRadius)
        {
            followDestinationSetter.target = fleeTarget.transform;
            wantsToWander = false;
        }
        
}
}
