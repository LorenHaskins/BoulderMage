using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceController : MonoBehaviour {
    private Animator anim;
    private boulderController boulder;
    private SpriteRenderer sprite;
    private float alpha;
    public GameObject iDontWantToGoPrefab;
    public Transform iDontWantToGoSpawn;



    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        boulder = boulderController.boulder;
        sprite = GetComponent<SpriteRenderer>();
        alpha = 1f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Idle to Move Animations
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
            Invoke("DecreaseAlphaAndDestroy", 2);
            if (GameObject.FindWithTag("idontwanttogo") == null)
            {
                Instantiate(iDontWantToGoPrefab, iDontWantToGoSpawn.position, iDontWantToGoSpawn.rotation);
            }
            
            anim.SetBool("dying", true);
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
