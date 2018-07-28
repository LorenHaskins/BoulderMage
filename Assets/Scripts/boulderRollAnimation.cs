using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderRollAnimation : MonoBehaviour {
    public float rollSpeed;
    

	// Use this for initialization
	void Start () {
        rollSpeed = 2; //how fast the sprite rolls
    }
	
	// Update is called once per frame
	void Update () {

        if (playerController.hDirection == 0) //If player is not moving references playerController script
        {
            
        } else if (playerController.hDirection == 1) //if player is moving forward
        {
            transform.Rotate(Vector3.back * rollSpeed);
        } else if (playerController.hDirection == -1) //if player is moving backwards
        {
            transform.Rotate(Vector3.forward * rollSpeed);
        }

    }
}
