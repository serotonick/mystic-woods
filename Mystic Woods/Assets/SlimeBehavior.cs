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
    SlimeGFX slimeGFX;
    ShepherdGFX shepherdGFX;
    int idleCounter;
    float distanceToShepherd;
    float distanceToCat;
    public float followRadius;
    public bool wantsToWander;
    public bool followingShepherd;
    float directionOfCat;

    void Start()
    {   //Reset Variables
        followTarget = null;
        followingShepherd = false;
        wantsToWander = false;
        //Get some Components
        ai = GetComponent<IAstarAI>();
        wanderDestinationSetter = GetComponent<WanderingDestinationSetter>();
        followDestinationSetter = GetComponent<AIDestinationSetter>();
        slimeGFX = GetComponentInChildren<SlimeGFX>();
        shepherd = GameObject.Find("Shepherd");
        slime = GameObject.Find("Slime");
        cat = GameObject.Find("Cat");
    }
    void Update()
    {   
        
        //idleCounter = slimeGFX.idleAnimationCount;
        //Default behavior is to look for a new wander path.
        ComeToShepherd();
                
            if(!followingShepherd && wantsToWander == true)
            {
                wanderDestinationSetter.PickWanderPath();
            }
            if (!ai.pathPending)
            {
            }
            
        //Reset wantsToWander when the max number of idle animations reached    
        /*if (idleCounter == 0)
        {
            wantsToWander = true;
            return;
        }*/
                
        //The variable followTarget is used to stor the target transform for follow behavior.
        //
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
        }
        
  } 
public void FleeFromCat()
{
        distanceToCat = Vector2.Distance(slime.transform.position, cat.transform.position);
        //print(distanceToCat);
        directionOfCat = Vector2.Angle(slime.transform.position, cat.transform.position);
        
}
}
