using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanging : MonoBehaviour
{
    SpriteRenderer background;
    public float changeSpeed = 0.5f;

    Color startColour;
    Color endColour;

    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<SpriteRenderer>(); //get the current background sprite
        startColour = background.color; //remember the current colour
        endColour = new Color(1f, startColour.g, startColour.b); //this colour is the same as above but redder
    }

    // Update is called once per frame
    void Update()
    {
        time += changeSpeed * Time.deltaTime; //increase the timer at the slow speed and the Time.deltaTime
        background.color = Color.Lerp(startColour, endColour, time); //change the background colour from the startcolour to the end colour at the time speed

        if (time >= 1f) //is enough time has passed
        {
            Color remember = startColour; //store the startcolour to remember it
            startColour = endColour; //switch the end and start colours
            endColour = remember;
            time = 0f; //reset the timer
        }
    }
}
