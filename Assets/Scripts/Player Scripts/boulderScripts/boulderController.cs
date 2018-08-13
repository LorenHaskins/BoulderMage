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
    public float hDirection;
    private GameObject staff;
    private staffController staffCtrl;
    private Animator anim;
    private Animator staffAnim;
    public GameObject gameManager;
    public playerStats PlayerStats;
    public float statMultiplyer;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        boulderCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        boulderDistance = 1;
        hDirection = 0;
        staff = GameObject.Find("staff");
        staffCtrl = staff.GetComponent<staffController>();
        staffAnim = staff.GetComponent<Animator>();

        gameManager = GameObject.Find("gameManager");
        PlayerStats = gameManager.GetComponent<playerStats>();

    }
	
	// Update is called once per frame
	void Update () {
        statMultiplyer = PlayerStats.playerSpeedStat;

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

            rb2d.velocity = (transform.right * hDirection * statMultiplyer);

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
