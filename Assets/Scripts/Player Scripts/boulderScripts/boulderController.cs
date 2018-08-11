using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class boulderController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private CircleCollider2D boulderCollider;
    private float staffLocation;
    private float boulderLocation;
    public float boulderDistance;
    private float hSpeed;
    public float hDirection;
    private GameObject staff;
    private staffController staffCtrl;
    private Animator anim;
    private Animator staffAnim;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        boulderCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        boulderDistance = 1;
        hDirection = 0;
        hSpeed = 1f;
        staff = GameObject.Find("staff");
        staffCtrl = staff.GetComponent<staffController>();
        staffAnim = staff.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        //Motion Controller
            boulderLocation = (Mathf.Round(boulderCollider.bounds.center.x * 100) / 100); //Where is the boulder
            staffLocation = staffCtrl.strikePoint;

            //Move Boulder With Staff
            if (((boulderLocation + boulderDistance) > staffLocation) && (staffLocation > (boulderLocation + -boulderDistance)))
            {
                hDirection = 0;
                staffAnim.SetBool("comeAlive",true);

            } else if (staffLocation > (boulderLocation + boulderDistance))
            {
                hDirection = 1;
                
            } else if (staffLocation < (boulderLocation + -boulderDistance))
            {
                hDirection = -1;
            }

            rb2d.velocity = (transform.right * hSpeed * hDirection);

     //   //Animator Controller
            if (hDirection == 0)
            {
                anim.SetBool("idle", true);
                anim.SetBool("move", false);
            } else if (hDirection != 0)
            {
                anim.SetBool("move", true);
                anim.SetBool("idle", false);
            }

            if (hDirection == 1)
            {
                transform.localScale = new Vector2(1, 1);
            } else if (hDirection == -1)
            {
                transform.localScale = new Vector2(-1, 1);
            }

            //Flip Sprite when Firing
            if (staffAnim.GetCurrentAnimatorStateInfo(0).IsName("staffShoot"))
            {
            if (staffCtrl. strikePoint < staffCtrl.moveLocation)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (staffCtrl.strikePoint > staffCtrl.moveLocation)
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }
}
