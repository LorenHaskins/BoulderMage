using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D col;
    private AudioSource sound;
    bool animState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        sound.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animState("lightningStrike"))
        {
            sound.enabled = true;
        }
        if (animState("destroy"))
        {
            Destroy(gameObject, 1);
        }
    }

    
}
