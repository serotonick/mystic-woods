using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class WanderingDestinationSetter : MonoBehaviour
{
    // Start is called before the first frame update

    public float wanderRadius = 1;


    IAstarAI ai;

    void Start () {
        ai = GetComponent<IAstarAI>();
    }
    Vector3 PickRandomPoint () {
        var point = Random.insideUnitSphere * wanderRadius;
        point.y = 0;
        point += ai.position;
        return point;
    }
    public void PickWanderPath () {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) {
            ai.destination = PickRandomPoint();
            ai.SearchPath();
        }

        }
}

