using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceController : MonoBehaviour {
    private Animator anim;
    private Animator staffAnim;
    private boulderController boulder;
    private staffController staff;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        staffAnim = staffController.anim;
        boulder = boulderController.boulder;
        staff = staffController.staff;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Idle to Move Animations
        if (boulder.hDirection == 0)
        {
            anim.SetBool("idle", true);
            anim.SetBool("move", false);
        }
        else if (boulder.hDirection != 0)
        {
            anim.SetBool("move", true);
            anim.SetBool("idle", false);
        }
    }
}
