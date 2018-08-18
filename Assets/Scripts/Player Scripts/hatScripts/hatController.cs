using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatController : MonoBehaviour {
    private Animator anim;
    private boulderController boulder;

    // Use this for initialization
    void Start () {
        boulder = boulderController.boulder;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //Motion Controller


        //Animation Controller
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
