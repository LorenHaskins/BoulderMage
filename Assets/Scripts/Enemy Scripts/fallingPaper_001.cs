﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPaper_001 : MonoBehaviour {

    public Rigidbody2D rb2d; // Rigid Body reference
    private float hDirection; //Horizontal direction
    public float hSpeed; //speed character can move on a horizontal plane
    public Animator anim; // Calls animator
    public CircleCollider2D boulderCollider;
    private float boulderLocation;
    private GameObject boulder;
    private float selfLocation;
    public BoxCollider2D selfCollider;
    private GameObject staff;
    private BoxCollider2D staffCollider;
    private bool whenDestroyed;
    private float worthXP;
    public GameObject player;
    public float givePlayerExp;
    public playerStats PlayerStats;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        boulder = GameObject.Find("boulder");
        boulderCollider = boulder.GetComponent<CircleCollider2D>();
        hSpeed = 1f;
        hDirection = 0;
        selfCollider = GetComponent<BoxCollider2D>();
        staff = GameObject.Find("staff");
        staffCollider = staff.GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        PlayerStats = player.GetComponent<playerStats>();
        givePlayerExp = PlayerStats.playerExp;
        worthXP = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        updateVariables();

        if (whenDestroyed)
        {
            givePlayerExp += worthXP;
            Destroy(gameObject, 0f);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "topGround")
        {
            if (selfLocation > boulderLocation)
            {
                hDirection = -1;
            }
            else if (selfLocation < boulderLocation)
            {
                hDirection = 1;
            }
            rb2d.velocity = (transform.right * hSpeed * hDirection);
        }

        if (col.gameObject.name == "staff")
        {
            Physics2D.IgnoreCollision(staffCollider, selfCollider);
        }

        if (col.gameObject.tag == "aura")
        {
            Debug.Log("HIT WITH AURA");
            anim.SetTrigger("hitAura");
        }

        if (col.gameObject.tag == "lightning")
        {
            Debug.Log("HIT WITH LIGHTNING");
            anim.SetTrigger("hitLightning");
        }
    }

    void updateVariables() //Variables that need to update every single frame
    {
        whenDestroyed = anim.GetCurrentAnimatorStateInfo(0).IsName("destroy");
        boulderLocation = (Mathf.Round(boulderCollider.bounds.center.x * 100) / 100);
        selfLocation = (Mathf.Round(selfCollider.bounds.center.x * 100) / 100);
    }

}