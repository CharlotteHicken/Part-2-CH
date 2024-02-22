using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    SpriteRenderer sr;
    Color baseColor;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        baseColor = sr.color;
        Selected(false);
    }

    public void OnMouseDown()
    {
        Selected(true);
    }

    public void OnMouseUp()
    {
        Selected(false); 
    }

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
}
