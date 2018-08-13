using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunrise : MonoBehaviour {
    public SpriteRenderer sprite;
    public GameObject wordStaff;
    public openingMoveStaff wordStaffCtrl;
    public Animator anim;
    public AudioSource sound;

	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        wordStaff = GameObject.Find("wordStaff");
        wordStaffCtrl = wordStaff.GetComponent<openingMoveStaff>();
        sprite.enabled = false;
        anim.enabled = false;
        sound.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (wordStaffCtrl.vDirection == 0)
        {
            sprite.enabled = true;
            anim.enabled = true;
            sound.enabled = true;
        }
	}
}
