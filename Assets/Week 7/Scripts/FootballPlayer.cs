using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    SpriteRenderer sr;
    Color baseColor;
    Rigidbody2D rb;
    public float speed = 15;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        baseColor = sr.color;
        Selected(false);
    }

    public void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    //public void OnMouseUp()
    //{
    //    Selected(false); 
    //}

    public void Selected(bool isSeleceted)
    {
        if (isSeleceted)
        {
            sr.color = Color.cyan;
        }
        if (!isSeleceted)
        {
            sr.color = baseColor;
        }
    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
}
