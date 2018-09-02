using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraController : MonoBehaviour {
    private Animator anim;
    private Animator staffAnim;
    private StaffController staff;
    private Rigidbody2D rb2d;
    private float hSpeed;
    private float hDirection;
    private float auraFly;
    private float lifetime;
    private AudioSource sound;
    bool animState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        staff = StaffController.staff;
        sound = GetComponent<AudioSource>();
        sound.enabled = false;
        hSpeed = 2;
        hDirection = staff.staffFacing;
        lifetime = 6f;


        if (staff.staffFacing == 1)
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
        //Destroy after Lifetime of seconds
        Destroy(gameObject, lifetime);

        //Gives aura movement, also sound, also if it hits an object it stops moving
        if (animState("auraSpawn"))
            {
            auraFly = 1;
            sound.enabled = true;
            }

        if (animState("auraDestroy"))
            {
            auraFly = 0;
            Destroy(gameObject, 0f);
            }

        applyMovementSpeed();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            anim.SetBool("destroyAura", true);
        }
    }

    void applyMovementSpeed()
    {
        rb2d.velocity = (transform.right * hSpeed * hDirection * auraFly);
    }
}
