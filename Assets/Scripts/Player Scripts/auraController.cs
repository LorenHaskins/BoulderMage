using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraController : MonoBehaviour {
    private Animator anim;
    private GameObject staff;
    private Animator staffAnim;
    private staffController staffCtrl;
    private Rigidbody2D rb2d;
    private float hSpeed;
    private float hDirection;
    private float auraFly;
    private float lifetime;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        staff = GameObject.Find("staff");
        staffAnim = staff.GetComponent<Animator>();
        staffCtrl = staff.GetComponent<staffController>();
        hSpeed = 2;
        hDirection = staffCtrl.staffFacing;
        lifetime = 6f;

        if (staffCtrl.staffFacing == 1)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("auraSpawn"))
            {
            auraFly = 1;
            } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("auraDestroy"))
            {
            auraFly = 0;
            }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("destroyObject"))
        {
            Destroy(gameObject, 0f);
        }

        rb2d.velocity = (transform.right * hSpeed * hDirection * auraFly);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            anim.SetBool("destroyAura", true);
        }
    }
}
