using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class openingMoveMage : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private BoxCollider2D col;
    public float hDirection;
    public BoxCollider2D ignoreCol;

    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        hDirection = -1.6f;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = (transform.right * hDirection);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "barrier")
        {
            hDirection = 0;
        }
    }
}
