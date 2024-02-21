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
        background = GetComponent<SpriteRenderer>();
        startColour = background.color;
        endColour = new Color(1f, startColour.g, startColour.b);
    }

    // Update is called once per frame
    void Update()
    {
        time += changeSpeed * Time.deltaTime;
        background.color = Color.Lerp(startColour, endColour, time);

        if (time >= 1f)
        {
            Color remember = startColour;
            startColour = endColour;
            endColour = remember;
            time = 0f;
        }
    }
}
