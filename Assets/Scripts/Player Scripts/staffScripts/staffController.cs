using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffController : MonoBehaviour {

    public Rigidbody2D rb2d; // Rigid Body reference
    public BoxCollider2D staffLightningPoint; //Box Collider to create reference for lightning
    private Vector3 mouseLocation; //Where the mouse is
    public float strikePoint; //Where the staff should end up
    public float moveLocation; // Where the mouse tells the staff to go
    public static float hDirection = 0; //Horizontal direction
    private float strikeBounds; //Give a boundary for lightning strikes on touch
    public bool strikeState; // Allow Lightning Strikes
    public bool auraState; //Allow Aura to be shot
    public float hSpeed; //speed character can move on a horizontal plane
    public Animator anim; // Calls animator
    public float staffMovement; //is the staff moving?
    public Vector2 localScale; //change object scale
    public bool singleClick;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); //reference rb2d
        staffLightningPoint = GetComponent<BoxCollider2D>(); //reference box collider
        anim = GetComponent<Animator>(); //reference animator
        hSpeed = 1f; //Horizontal Speed
        moveLocation = 0; //Default 0
        strikePoint = 0; //Default 0
        hDirection = 0; //Default 0, 1 is right, -1 is left
        strikeBounds = 0; //Default 0
    }
	
	// Update is called once per frame
	void Update () {

        //Motion Controller
            Vector3 mouseLocation = (Camera.main.ScreenToWorldPoint(Input.mousePosition)); //outputs mouse coordinates in real time
            strikePoint = (Mathf.Round(staffLightningPoint.bounds.center.x * 10) / 10); //x location for staff to move
            strikeBounds = (Mathf.Round(staffLightningPoint.bounds.center.y * 10) / 10); //mouse bounds for moving staff

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("staffLightning")) { //When lightning is not striking
                if (Input.GetMouseButtonDown(0)) //When left click
                {
                    singleClick = true;
                    moveLocation = (Mathf.Round(mouseLocation.x * 10) / 10); //creates x location for staff
                    if (mouseLocation.y > strikeBounds) //staff will move
                    {
                        strikeState = true;
                        auraState = false;
                    } else //staff will not move
                    {
                        if (singleClick == true)
                        {
                            auraState = true;
                            strikeState = false;   
                        }
                        else
                        {
                            auraState = false;
                        }
                    }
                }
            }

            //Decides which direction the staff will move
            if ((moveLocation > strikePoint) && (strikeState == true))
            {
                hDirection = 1;
            } else if ((moveLocation < strikePoint) && (strikeState == true))
            {
                hDirection = -1;
            } else
            {
                hDirection = 0;
                strikeState = false; //Causes the boulder to stop jittering, and ceases the strike state
            }
            rb2d.velocity = (transform.right * hSpeed * hDirection);

        //Animator Controller
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
                    }
                    else if (strikePoint > moveLocation)
                    {
                        transform.localScale = new Vector2(-1, 1);
                    }

            //Aura Shoot

                if (auraState == true)
                {
                    anim.SetBool("shoot", true);
                    singleClick = false;
                    auraState = false;
                }   else
                {
                    anim.SetBool("shoot", false);
                }
    }
}
