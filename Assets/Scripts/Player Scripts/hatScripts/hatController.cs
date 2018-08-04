using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatController : MonoBehaviour {
    private Animator anim;
    private GameObject boulder;
    private boulderController boulderCtrl;

    // Use this for initialization
    void Start () {
        boulder = GameObject.Find("boulder");
        boulderCtrl = boulder.GetComponent<boulderController>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //Motion Controller


        //Animation Controller
        if (boulderCtrl.hDirection == 0)
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
