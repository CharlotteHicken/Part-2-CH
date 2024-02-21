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
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())//if the mouse is clicked, and the player is notclicking on the cat or UI
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //set mouseposition to that new position
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

        timer += Time.deltaTime; //timer slowly increases each second

        if (timer > meterDown) //when enough seconds have passed, decrease the catmeter slider, and reset the timer
        {
            SendMessage("CatMeter", -1);
            timer = 0;
        }

    }

    private void OnMouseDown()
    {
        clickingOnSelf = true; //when the player clicks on the cat, it will increase the catmeter, and play the meow animation
        SendMessage("CatMeter", 1);
        animator.SetTrigger("Meow");
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false; //when player unclicks, the cat can move again!
    }

    public void CatMeter(float meter)
    {
        catMeter += meter; //change the catmeter based on the inputed value
        catMeter = Mathf.Clamp(catMeter, 0, catMax); //clamp the value so it is not too small or too big.
        if (catMeter == 0) //if the cat meter reaches 0, play the sleep animation stuff (so the cat doesn't die because that is sad)
        {
            animator.SetTrigger("Sleep"); 
            SendMessage("CatMeter", 5);
        }

        if (meter == 2) //if the input is 2, play the cat stretch
        {
            animator.SetTrigger("Stretch");
        }

        if (meter == 3) //if the input is 3, play the lick animation
        {
            animator.SetTrigger("Lick");
        }

        if (meter == 5) //if input is 5 play the sleep animation
        {
            animator.SetTrigger("Sleep");
        }

    }

}
