using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControls : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 4;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    public float catMeter;
    public float catMax = 10;
    bool clickingOnSelf = false;
    float timer = 0;
    public float meterDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        catMeter = catMax;
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position; //moves the player's destination, by subtracting the current position to get towards the goal
        if (movement.x > 0) //if movement is positive, flip to face this way
        {
            sr.flipX = false;
        }
        if (movement.x < 0) //if movement is negative, flip to face that way
        {
            sr.flipX = true;
        }

        if(movement.magnitude < 0.1) //if position is almost at the goal, set movement. (this prevents jittering)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime); //move the player in the right direction and by this speed and 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //when mouse is clicked, set mosuposition to that new position
            destination = new Vector2(mousePosition.x, transform.position.y); //set destination to the x of that mouse click, but keep the current y.
        }

        animator.SetFloat("Speed", movement.magnitude); //animate based on the speed and movement.magnitude

        if (movement.magnitude > 2.1) //if movement is far away, speed up
        {
            speed = 6;
        }
        else //resets to default speed
        {
            speed = 4;
        }

        timer += Time.deltaTime;

        if (timer > meterDown)
        {
            SendMessage("CatMeter", -1);
            timer = 0;
        }

    }

    private void OnMouseDown()
    {
        clickingOnSelf = true;
        SendMessage("CatMeter", 1);
        animator.SetTrigger("Meow");
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    public void CatMeter(float meter)
    {
        catMeter += meter;
        catMeter = Mathf.Clamp(catMeter, 0, catMax);
        if (catMeter == 0)
        {
            animator.SetTrigger("Sleep");
            SendMessage("CatMeter", 5);
        }

        if (meter == 2)
        {
            animator.SetTrigger("Stretch");
        }

        if (meter == 3)
        {
            animator.SetTrigger("Lick");
        }

        if (meter == 5)
        {
            animator.SetTrigger("Sleep");
        }

    }

}
