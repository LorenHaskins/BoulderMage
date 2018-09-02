using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvBarrier : MonoBehaviour {
    private Animator anim;
    private RuneScriptInv invRune;
    public GameObject boulder;
    public boulderController boulderCtrl;
    bool animState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        invRune = RuneScriptInv.rune;
        anim.SetBool("activation", true);
        boulderCtrl = boulderController.boulder;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = boulderCtrl.transform.position;
        boulderCtrl.boulderCollider.enabled = false;

        if (invRune.activate == false)
        {
            anim.SetBool("activation", false);
        }

        if (animState("Destroy"))
        {
            boulderCtrl.boulderCollider.enabled = true;
            Destroy(gameObject, 0);
        }
	}
}
