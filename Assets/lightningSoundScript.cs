using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningSoundScript : MonoBehaviour {
    private AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(gameObject, 2);
    }
}
