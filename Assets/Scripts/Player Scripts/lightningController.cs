using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningController : MonoBehaviour
{
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
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        staff = GameObject.Find("staff");
        staffAnim = staff.GetComponent<Animator>();
        staffCtrl = staff.GetComponent<staffController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("destroy"))
        {
            Destroy(gameObject, 0);
        }
    }
}
