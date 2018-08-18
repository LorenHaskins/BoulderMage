using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningController : MonoBehaviour
{
    private Animator anim;
    bool animState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animState("destroy"))
        {
            Destroy(gameObject, 0);
        }
    }

    
}
