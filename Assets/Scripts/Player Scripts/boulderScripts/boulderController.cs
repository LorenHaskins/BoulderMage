using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class boulderController : MonoBehaviour {

    public static boulderController boulder;

    private Rigidbody2D rb2d;
    private CircleCollider2D boulderCollider;
    private float staffLocation;
    private float boulderLocation;
    public float boulderDistance;
    public float hDirection;
    private staffController staff;
    private Animator anim;
    public playerStats pS;
    public float statMultiplyer;
    public float maxVelocity;

    // Use this for initialization
    void Awake()
    {
        //This allows this object to be the only object in existance
        if (boulder == null)
        {
            boulder = this;
        }
        else if (boulder != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        boulderCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        boulderDistance = 1;
        hDirection = 0;
        staff = staffController.staff;
        pS = playerStats.stats;

    }
	
	// Update is called once per frame
	void Update () {
        updateVariables();

        //Motion Controller
        boulderLocation = (Mathf.Round(boulderCollider.bounds.center.x * 100) / 100); //Where is the boulder
            staffLocation = staff.strikePoint;

            //Move Boulder With Staff
            if (((boulderLocation + boulderDistance) > staffLocation) && (staffLocation > (boulderLocation + -boulderDistance)))
            {
                hDirection = 0;

            } else if (staffLocation > (boulderLocation + boulderDistance))
            {
                hDirection = 1;
                
            } else if (staffLocation < (boulderLocation + -boulderDistance))
            {
                hDirection = -1;
            }

        applyMovementSpeed();

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
            if (staff.animShoot)
            {
            if (staff. strikePoint < staff.moveLocation)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (staff.strikePoint > staff.moveLocation)
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }

    void updateVariables()
    {
        statMultiplyer = pS.actualPlayerSpeed;
        maxVelocity = (hDirection * statMultiplyer);
    }

    void applyMovementSpeed()
    {
            rb2d.velocity = (transform.right * maxVelocity);
    }
}
