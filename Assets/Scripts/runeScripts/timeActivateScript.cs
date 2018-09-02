using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeActivateScript : MonoBehaviour {
    private Animator anim;
    bool animState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }
    public static RuneScriptTime timeRune;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        timeRune = RuneScriptTime.rune;
    }
	
	// Update is called once per frame
	void Update () {
		if (timeRune.runeActive == true)
        {
            anim.SetBool("active", true);
        } else
        {
            anim.SetBool("active", false);
        }

        if (animState("destroy"))
        {
            Destroy(gameObject, 0);
        }
	}
}
