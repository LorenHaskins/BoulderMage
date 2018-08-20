using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffController : MonoBehaviour {

    public static staffController staff;
    public bool animLightning;
    public bool animIdle;
    public bool animMotion;
    public bool animShoot;
    public Rigidbody2D rb2d; // Rigid Body reference
    public BoxCollider2D staffLightningPoint; //Box Collider to create reference for lightning
    public float strikePoint; //Where the staff should end up
    public float moveLocation; // Where the mouse tells the staff to go
    public static float hDirection = 0; //Horizontal direction
    public bool strikeState; // Allow Lightning Strikes
    public bool auraState; //Allow Aura to be shot
    public static Animator anim; // Calls animator
    public float staffMovement; //is the staff moving?
    public Vector2 localScale; //change object scale
    private float strikeBounds; //Give a boundary for lightning strikes on touch
    private Vector3 mouseLocation; //Where the mouse is
    public GameObject auraPrefab;
    public Transform auraSpawn;
    public GameObject lightningPrefab;
    public Transform lightningSpawn;
    public float staffFacing;
    public playerStats pS;
    public float statMultiplyer;
    bool animState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }
    bool mouseClick() { return Input.GetMouseButtonDown(0); }
    public RuneScriptSpeed RuneScriptSpeed;
    public float runeMultiplyer;
    public float velocity;
    public float maxVelocity;
    private AudioSource sound;
    public AudioClip lightningCharge;

    // Use this for initialization
    void Awake()
    {
        //This allows this object to be the only object in existance
        if (staff == null)
        {
            staff = this;
        }
        else if (staff != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); //reference rb2d
        staffLightningPoint = GetComponent<BoxCollider2D>(); //reference box collider
        anim = GetComponent<Animator>(); //reference animator
        moveLocation = 0; //Default 0
        strikePoint = 0; //Default 0
        hDirection = 0; //Default 0, 1 is right, -1 is left
        strikeBounds = 0; //Default 0
        strikeState = false;
        pS = playerStats.stats;
        RuneScriptSpeed = RuneScriptSpeed.rune;
        runeMultiplyer = pS.runeMultiplyerSpeed;
        sound = GetComponent<AudioSource>();
    }

    float roundToTenths(float x)
    {
        return (Mathf.Round(x * 10) / 10);
    }

    // Update is called once per frame
    void Update() {
        updateVariables();
        updateAnimation();
        updateMotion();
        updateDependantAnimation();
    }
    
    void updateVariables()
    {
        statMultiplyer = pS.actualPlayerSpeed;
        maxVelocity = (hDirection * statMultiplyer);
    }

    void updateMotion()
    {
            applyMovementSpeed();

            //Motion Controller
            Vector3 mouseLocation = (Camera.main.ScreenToWorldPoint(Input.mousePosition)); //outputs mouse coordinates in real time
            strikePoint = roundToTenths(staffLightningPoint.bounds.center.x); //x location for staff to move
            strikeBounds = roundToTenths(staffLightningPoint.bounds.center.y); //mouse bounds for moving staff

            if (!animState("staffLightning"))
            {
                if (mouseClick())
                {
                    moveLocation = roundToTenths(mouseLocation.x); //creates x location for staff
                    if (mouseLocation.y > strikeBounds) //staff will move
                    {
                        strikeState = true;
                        auraState = false;
                    }
                    else if ((mouseLocation.y > -7) && (mouseLocation.y < strikeBounds))//staff will not move
                    {
                        auraState = true;
                    }
                }
            } 

            //Decides which direction the staff will move
            if ((moveLocation > strikePoint) && (strikeState == true))
            {
                hDirection = 1;
            }
            else if ((moveLocation < strikePoint) && (strikeState == true))
            {
                hDirection = -1;
            }
            else if ((strikeState == true))
            {
                hDirection = 0;
                strikeLightning();
                strikeState = false; //Causes the boulder to stop jittering, and ceases the strike state
            } 


    }

    void updateAnimation()
    {
        staffMovement = staffController.hDirection;


        if (strikeState == false)
        {
            anim.SetBool("lightning", false);
            animLightning = false;
        }

        if (staffMovement == 0)
        {
            anim.SetBool("motion", false);
            animMotion = false;
        } else
        {
            anim.SetBool("motion", true);
            animMotion = true;
        }

        //Flip Sprite
        if (!animState("staffShoot"))
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
                    if (!animState("staffShoot"))
                    {
                        shootAura(); //Look below for script to shoot aura
                    }
                    anim.SetBool("shoot", true);
                    animShoot = true;
                    auraState = false;
                }
                else
                {
                    anim.SetBool("shoot", false);
                    animShoot = false;
                }
    }

    void shootAura()
    {
        if (!animState("staffShoot"))
        {
            Debug.Log("SHOOT AURA");
            // Create the Bullet from the Bullet Prefab
            var aura = (GameObject)Instantiate(
                auraPrefab,
                auraSpawn.position,
                auraSpawn.rotation);
        }
    }

    void strikeLightning()
    {
        anim.SetBool("lightning", true);
        sound.Play();
        animLightning = true;
        if (!animState("staffShoot"))
        {
            Debug.Log("SHOOT Lightning");
            // Create the Bullet from the Bullet Prefab
            var lightning = (GameObject)Instantiate(
                lightningPrefab,
                lightningSpawn.position,
                lightningSpawn.rotation);
        }
         
    }

    void applyMovementSpeed()
    {
        //This causes the staff to "warp" to location if it's within the maxVelocity distance. Removes all jitter from staff movement.
        if (Mathf.Abs(moveLocation - strikePoint) < (maxVelocity/24))
        {
            transform.position = new Vector2(moveLocation, transform.position.y);
            rb2d.velocity = (transform.right * 0);
            hDirection = 0;
        }
        else
        {
            rb2d.velocity = (transform.right * maxVelocity);
        }
    }

    void updateDependantAnimation()
    {


        if (anim.GetBool("shoot") == true)
        {
            
        }
}
}
