using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceController : MonoBehaviour {
    private Animator anim;
    private GameObject staff;
    private Animator staffAnim;
    private GameObject boulder;
    private boulderController boulderCtrl;
    private staffController staffCtrl;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        staff = GameObject.Find("staff");
        staffAnim = staff.GetComponent<Animator>();
        boulder = GameObject.Find("boulder");
        boulderCtrl = boulder.GetComponent<boulderController>();
        staffCtrl = staff.GetComponent<staffController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Idle to Move Animations
        if ((boulderCtrl.hDirection == 0) && (staffCtrl.staffMovement == 0))
        {
            anim.SetBool("idle", true);
            anim.SetBool("move", false);
        }
        else if (boulderCtrl.hDirection != 0)
        {
            anim.SetBool("move", true);
            anim.SetBool("idle", false);
        }
    }
}
