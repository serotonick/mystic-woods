using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ShepherdGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
                if(aiPath.desiredVelocity.x >= 0.01f)
    {
            transform.localScale = new Vector3(1f, 1f, 1f);
    } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void FixedUpdate()
    {
        if(aiPath.desiredVelocity.x != 0 || aiPath.desiredVelocity.y != 0){
            animator.SetBool("isMoving", true);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }
    }
}
