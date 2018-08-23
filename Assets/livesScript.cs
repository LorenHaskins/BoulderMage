using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesScript : MonoBehaviour {
    private Animator anim;
    public playerStats pS;

    // Use this for initialization
    private void Start()
    {
        pS = playerStats.stats;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        anim.SetInteger("lives", pS.lives);
	}
}
