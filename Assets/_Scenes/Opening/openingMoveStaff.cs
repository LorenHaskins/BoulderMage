using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class openingMoveStaff : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private BoxCollider2D col;
    public float vDirection;
    public BoxCollider2D ignoreCol;

    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        vDirection = 2.35f;
        Physics2D.IgnoreLayerCollision(14,14);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = (transform.up * vDirection);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "barrier")
        {
            vDirection = 0;
        }
    }
}
