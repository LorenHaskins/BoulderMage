using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffController : MonoBehaviour {

    public static StaffController staff;
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
    bool AnimState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }
    bool MouseClick() { return Input.GetMouseButtonDown(0); }
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
        anim = staff.GetComponent<Animator>(); //reference animator
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

    float RoundToTenths(float x)
    {
        return (Mathf.Round(x * 10) / 10);
    }

    // Update is called once per frame
    void Update() {
        UpdateVariables();
        UpdateAnimation();
        UpdateMotion();
    }
    
    void UpdateVariables()
    {
        statMultiplyer = pS.actualPlayerSpeed;
        maxVelocity = (hDirection * statMultiplyer);
    }

    void UpdateMotion()
    {
            ApplyMovementSpeed();

            //Motion Controller
            Vector3 mouseLocation = (Camera.main.ScreenToWorldPoint(Input.mousePosition)); //outputs mouse coordinates in real time
            strikePoint = RoundToTenths(staffLightningPoint.bounds.center.x); //x location for staff to move
            strikeBounds = RoundToTenths(staffLightningPoint.bounds.center.y); //mouse bounds for moving staff

            if (!AnimState("staffLightning"))
            {
                if (MouseClick())
                {
                    moveLocation = RoundToTenths(mouseLocation.x); //creates x location for staff
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
                StrikeLightning();
                strikeState = false; //Causes the boulder to stop jittering, and ceases the strike state
            } 


    }

    void UpdateAnimation()
    {
        staffMovement = StaffController.hDirection;
        
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
        if (!AnimState("staffShoot"))
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
                    if (!AnimState("staffShoot"))
                    {
                        ShootAura(); //Look below for script to shoot aura
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

    void ShootAura()
    {
        if (!AnimState("staffShoot"))
        {
            Debug.Log("SHOOT AURA");
            // Create Aura
            Instantiate(auraPrefab, auraSpawn.position, auraSpawn.rotation);

        }
    }

    void StrikeLightning()
    {
        anim.SetBool("lightning", true);
        sound.Play();
        animLightning = true;
        if (!AnimState("staffShoot"))
        {
            Debug.Log("SHOOT Lightning");
            //Create Lightning
            Instantiate(lightningPrefab, lightningSpawn.position, lightningSpawn.rotation);
        }
         
    }

    void ApplyMovementSpeed()
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

    void IsFaceGone()
    {
        if (GameObject.FindWithTag("face") != null)
        {
            Invoke("DecreaseAlphaAndDestroy", 2);
            anim.SetBool("dying", true);
        }
    }
}
