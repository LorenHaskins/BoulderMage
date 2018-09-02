using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDontWantToGoScript : MonoBehaviour
{
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        Invoke("AnimateAndDestroy", 0.5f);
    }

    void AnimateAndDestroy()
    {
        anim.enabled = true;
        Destroy(gameObject, 4);
    }
}
