using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorFaceBoulderHat : MonoBehaviour {
    private Animator anim;
    private GameObject staff;
    private Animator staffAnim;
    private staffController staffCtrl;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        staff = GameObject.Find("staff");
        staffAnim = staff.GetComponent<Animator>();
        staffCtrl = staff.GetComponent<staffController>();
    }
	
	// Update is called once per frame
	void Update () {
        //Animation Controller

        //Trigger Lightning Animation
        if (staffAnim.GetCurrentAnimatorStateInfo(0).IsName("staffLightning"))
        {
            anim.SetBool("lightning", true);
        }
        else
        {
            anim.SetBool("lightning", false);
        }

        //Trigger Aura Animation
        if (staffAnim.GetCurrentAnimatorStateInfo(0).IsName("staffShoot"))
        {
            anim.SetBool("shoot", true);
        }
        else
        {
            anim.SetBool("shoot", false);
        }
    }
}
