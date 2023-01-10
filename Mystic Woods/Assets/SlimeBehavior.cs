using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class SlimeBehavior : MonoBehaviour
{   
    //public float health;
    AIPath aiPath;
    public Collider2D slimeCollider;
    // Start is called before the first frame update
    void Start()
    {
        slimeCollider = GetComponent<Collider2D>();
        
    }
    /*public float Health
    {
        set
        {
            health = value;
        }
        get 
        {
            return health;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Wander()
    {

    }
    public void Attack()
    {

    }
    public void Idle()
    {

    }
    public void Damaged()
    {

    }
    public void Death()
    {

    }
}
