using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {
    // Current Movement Direction
    // (by default it moves to the right)
    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();

    // Use this for initialization
    void Start () {
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.3f, 0.3f);    
    }
   
    // Update is called once per frame
// Update is called once per Frame
void Update() {
    // Move in a new Direction?
    if (Input.GetKey(KeyCode.RightArrow))
        dir = Vector2.right;
    else if (Input.GetKey(KeyCode.DownArrow))
        dir = -Vector2.up;    // '-up' means 'down'
    else if (Input.GetKey(KeyCode.LeftArrow))
        dir = -Vector2.right; // '-right' means 'left'
    else if (Input.GetKey(KeyCode.UpArrow))
        dir = Vector2.up;
}
   
    void Move() {
    // Save current position (gap will be here)
    Vector2 v = transform.position;

    // Move head into new direction (now there is a gap)
    transform.Translate(dir);

    // Do we have a Tail?
    if (tail.Count > 0) {
        // Move last Tail Element to where the Head was
        tail.Last().position = v;

        // Add to front of list, remove from the back
        tail.Insert(0, tail.Last());
        tail.RemoveAt(tail.Count-1);
    }
}