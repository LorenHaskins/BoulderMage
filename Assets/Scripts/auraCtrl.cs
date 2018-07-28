using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraCtrl : MonoBehaviour
{

    public float auraSpd; //Speed of aura
    public float auraDir;
    public float auraLifespan;

    Rigidbody2D rb2d; //RB2D

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        auraSpd = 5;
        auraDir = 1;
        auraLifespan = 0.5f;
        Destroy(gameObject, auraLifespan);
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb2d.velocity = rb2d.velocity = (transform.right * auraSpd * auraDir);
    }
}
