using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffController : MonoBehaviour {

    public Rigidbody2D rb2d; // Rigid Body reference
    public BoxCollider2D staffLightningPoint; //Box Collider to create reference for lightning
    public float strikePoint; //Where the staff should end up
    public float moveLocation; // Where the mouse tells the staff to go
    public static float hDirection = 0; //Horizontal direction
    public bool strikeState; // Allow Lightning Strikes
    public bool auraState; //Allow Aura to be shot
    public Animator anim; // Calls animator
    public float staffMovement; //is the staff moving?
    public Vector2 localScale; //change object scale
    private float strikeBounds; //Give a boundary for lightning strikes on touch
    private Vector3 mouseLocation; //Where the mouse is
    public GameObject auraPrefab;
    public Transform auraSpawn;
    public GameObject lightningPrefab;
    public Transform lightningSpawn;
    public float staffFacing;
    public GameObject gameManager;
    public playerStats PlayerStats;
    public float statMultiplyer;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); //reference rb2d
        staffLightningPoint = GetComponent<BoxCollider2D>(); //reference box collider
        anim = GetComponent<Animator>(); //reference animator
        moveLocation = 0; //Default 0
        strikePoint = 0; //Default 0
        hDirection = 0; //Default 0, 1 is right, -1 is left
        strikeBounds = 0; //Default 0
        strikeState = false;

        gameManager = GameObject.Find("gameManager");
        PlayerStats = gameManager.GetComponent<playerStats>();
    }

    bool lightningInput()
    {
        return Input.GetMouseButtonDown(0);
    }

    bool isShootingLightning()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("staffLightning");
    }

    bool isShootingAura()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("staffAura");
    }

    float roundToOneDecimal(float x)
    {
        return (Mathf.Round(x * 10) / 10);
    }

    // Update is called once per frame
    void Update() {
        statMultiplyer = PlayerStats.playerSpeedStat;

        updateMotion();
        updateAnimation();
    }

    void updateMotion()
    {
            //Motion Controller
            Vector3 mouseLocation = (Camera.main.ScreenToWorldPoint(Input.mousePosition)); //outputs mouse coordinates in real time
            strikePoint = roundToOneDecimal(staffLightningPoint.bounds.center.x); //x location for staff to move
            strikeBounds = roundToOneDecimal(staffLightningPoint.bounds.center.y); //mouse bounds for moving staff

            if (!isShootingLightning())
            {
                if (lightningInput())
                {
                    moveLocation = roundToOneDecimal(mouseLocation.x); //creates x location for staff
                    if (mouseLocation.y > strikeBounds) //staff will move
                    {
                        strikeState = true;
                        auraState = false;
                    }
                    else //staff will not move
                    {
                        auraState = true;
                    }
                }
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("staffLightning") && (strikeState == true))
            {
                strikeLightning();
            }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("staffInGround"))
        {
            //Decides which direction the staff will move
            if ((moveLocation > strikePoint) && (strikeState == true))
            {
                hDirection = 1;
            }
            else if ((moveLocation < strikePoint) && (strikeState == true))
            {
                hDirection = -1;
            }
            else if (strikeState == true)
            {
                hDirection = 0;
                strikeLightning();
                strikeState = false; //Causes the boulder to stop jittering, and ceases the strike state
            }
        }

        rb2d.velocity = (transform.right *  hDirection * statMultiplyer);
    }

    void updateAnimation()
    {
        staffMovement = staffController.hDirection;

        //Set Walking Movement
        if (staffMovement == 0)
        {
            anim.SetBool("motion", false);
            anim.SetBool("lightning", true);
        }
        else
        {
            anim.SetBool("motion", true);
            anim.SetBool("lightning", false);
        }

        //Flip Sprite
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("staffShoot"))
            if (strikePoint < moveLocation)
            {
                transform.localScale = new Vector2(1, 1);
                staffFacing = 1;
            }
            else if (strikePoint > moveLocation)
            {
                transform.localScale = new Vector2(-1, 1);
                staffFacing = -1;
            }

            //Aura Shoot
                if (auraState == true)
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("staffShoot"))
                    {
                    shootAura(); //Look below for script to shoot aura
                    }
                    anim.SetBool("shoot", true);
                    auraState = false;
                }
                else
                {
                    anim.SetBool("shoot", false);
                }
    }

    void shootAura()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("staffShoot"))
        {
            Debug.Log("SHOOT AURA");
            // Create the Bullet from the Bullet Prefab
            // Create the Bullet from the Bullet Prefab
            var aura = (GameObject)Instantiate(
                auraPrefab,
                auraSpawn.position,
                auraSpawn.rotation);
        }
    }

    void strikeLightning()
    {
        Debug.Log("SHOOT Lightning");
        // Create the Bullet from the Bullet Prefab
        // Create the Bullet from the Bullet Prefab
        var lightning = (GameObject)Instantiate(
            lightningPrefab,
            lightningSpawn.position,
            lightningSpawn.rotation);
    }
}
