using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{   
    public float health;
    Collider2D slimeCollider;
    // Start is called before the first frame update
    void Start()
    {
        slimeCollider = GetComponent<Collider2D>();
    }
    public float Health
    {
        set
        {
            health = value;
        }
        get 
        {
            return health;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attack")
        {
         print("hit!");
        }
    }
}
