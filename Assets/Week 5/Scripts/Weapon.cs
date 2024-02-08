using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 5;
    Rigidbody2D rb;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
        Destroy(prefab, 5);
    }

    private void Update()
    {
        destination = new Vector2(transform.position.x - 5, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(prefab);
    }
}
