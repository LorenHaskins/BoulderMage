using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public Rigidbody2D rb2d; // Rigid Body reference
    private BoxCollider2D staffLightningPoint; //Box Collider to create reference for lightning
    private Vector3 mouseLocation; //Where the mouse is
    private float strikePoint; //Where the staff should end up
    private float moveLocation; // Where the mouse tells the staff to go
    public static float hDirection = 0; //Horizontal direction
    private float strikeBounds; //Give a boundary for lightning strikes on touch
    private bool strikeState; // Allow Lightning Strikes
    public float hSpeed; //speed character can move on a horizontal plane
    public float auraVelocity; //Speed of the aura projectile
    public GameObject auraPrefab; //Assign Prefab for projectile
    public bool auraMouseClick; //Did the mouse try to shoot an aura

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        staffLightningPoint = GetComponent<BoxCollider2D>();
        hSpeed = 1; //Horizontal Speed
        moveLocation = 0; //Default 0
        strikePoint = 0; //Default 0
        hDirection = 0; //Default 0, 1 is right, -1 is left
        strikeBounds = 0; //Default 0
        auraVelocity = 5; //Speed that the projectile goes
        auraMouseClick = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouseLocation = (Camera.main.ScreenToWorldPoint(Input.mousePosition)); //outputs mouse coordinates in real time
        strikePoint = (Mathf.Round(staffLightningPoint.bounds.center.x * 10) / 10);
        strikeBounds = (Mathf.Round(staffLightningPoint.bounds.center.y * 10) / 10);

        if (Input.GetMouseButtonDown(0)) //When left click
        {
            moveLocation = (Mathf.Round(mouseLocation.x * 10) / 10); //Creates the location to move the boulder if possible
            Debug.Log("Move Location X" + moveLocation);
            Debug.Log("Strike Point X" + strikePoint);
            Debug.Log("Strike Bounds Y" + strikeBounds);
            if (mouseLocation.y > strikeBounds) //The boulder will move but not shoot.
            {
                strikeState = true;
                auraMouseClick = false;
            } else //The boulder will not move, but will shoot.
            {
                strikeState = false;
                auraMouseClick = true;
            }
        }



        if ((moveLocation > strikePoint) && (strikeState == true))
        {
            hDirection = 1;
        } else if ((moveLocation < strikePoint) && (strikeState == true))
        {
            hDirection = -1;
        } else
        {
            hDirection = 0;
        }

        rb2d.velocity = (transform.right * hSpeed * hDirection);
	}
}
