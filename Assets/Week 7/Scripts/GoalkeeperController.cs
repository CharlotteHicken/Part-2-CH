using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 distance;
    
    Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Controller.SelectedPlayer == null) return;
        
        rb.MovePosition(distance);
    }

    private void Update()
    {
        if (Controller.SelectedPlayer == null) return;

        distance = ((Vector2)Controller.SelectedPlayer.transform.position - originalPosition).normalized;

        distance = distance / originalPosition.magnitude;
    }
}
