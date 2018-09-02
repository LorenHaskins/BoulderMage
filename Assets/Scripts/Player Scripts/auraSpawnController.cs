using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraSpawnController : MonoBehaviour {
    private boulderController boulder;
    private AudioSource sound;

    // Use this for initialization
    void Start () {
        boulder = boulderController.boulder;
        sound = GetComponent<AudioSource>();
        sound.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (boulder.anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot"))
            {
            sound.enabled = true;
            } else
        {
            sound.enabled = false;
        }
	}
}
