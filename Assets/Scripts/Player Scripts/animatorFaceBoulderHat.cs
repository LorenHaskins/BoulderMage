using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorFaceBoulderHat : MonoBehaviour {
    private Animator anim;
    private StaffController staff;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        staff = StaffController.staff;
    }
	
	// Update is called once per frame
	void Update () {
        //Animation Controller

        //Trigger Lightning Animation
        if (staff.animLightning)
        {
            anim.SetBool("lightning", true);
        }
        else
        {
            anim.SetBool("lightning", false);
        }

        //Trigger Aura Animation
        if (staff.animShoot)
        {
            anim.SetBool("shoot", true);
        }
        else
        {
            anim.SetBool("shoot", false);
        }
    }


}
