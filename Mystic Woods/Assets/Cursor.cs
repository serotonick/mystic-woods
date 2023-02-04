using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Pathfinding;
public class Cursor : MonoBehaviour
{
    public AIDestinationSetter shepherd;
    Transform cursor;
    void Start()
    {
        shepherd = GetComponentInParent<AIDestinationSetter>();
        shepherd.target = null;

    }
    void Update()
    {
        cursor = GameObject.FindWithTag("Cursor").transform;
    }
    void OnFire()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localPosition = new Vector2(cursorPosition.x,cursorPosition.y);
        shepherd.target = cursor;
    }
    // OnFire is called on click
    /*void FixedUpdate()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPosition.x,cursorPosition.y);
    }*/
    // Update is called once per frame

}
