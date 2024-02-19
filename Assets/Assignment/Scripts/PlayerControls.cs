using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 4;
    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position; //moves the player's destination, by subtracting the current position to get towards the goal
        if(movement.magnitude < 0.1) //if position is almost at the goal, set movement. (this prevents jittering)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime); //move the player in the right direction and by this speed and 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination = new Vector2(mousePosition.x, transform.position.y);
        }

        animator.SetFloat("Speed", movement.magnitude); //animate based on the speed and movement.magnitude

        if (movement.magnitude > 2.1)
        {
            speed = 6;
        }
        else
        {
            speed = 4;
        }
    }
}
