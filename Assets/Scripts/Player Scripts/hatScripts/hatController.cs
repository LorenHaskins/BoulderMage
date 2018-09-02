using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatController : MonoBehaviour {
    private Animator anim;
    private boulderController boulder;
    private SpriteRenderer sprite;
    private float alpha;


    // Use this for initialization
    void Start () {
        boulder = boulderController.boulder;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        alpha = 1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
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

        if (GameObject.FindWithTag("deathSequence") != null)
        {
            Invoke("DecreaseAlphaAndDestroy",0);
        }
    }

    void DecreaseAlphaAndDestroy()
    {
        alpha += -0.01f;
        sprite.color = new Color(1, 1, 1, alpha);

        if (alpha <= 0)
        {
            Destroy(gameObject, 0);
        }
    }
}
