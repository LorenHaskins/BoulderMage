using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathToBoulderMage : MonoBehaviour {
    protected SpriteRenderer sprite;
    protected float alpha;
    protected string nextScene;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Debug.Log("HELLO I AM DEATH TO BOULDER SCRIPT");
        alpha = 1f;
    }

    private void Update()
    {
        if (GameObject.FindWithTag("deathSequence") != null)
        {
            Debug.Log("UHHHH DIE DIE DIE");
            DecreaseAlphaAndDestroy();
        }
    }

    protected void DecreaseAlphaAndDestroy()
    {
        alpha += -0.01f;
        sprite.color = new Color(1, 1, 1, alpha);

        if (alpha <= 0)
        {
            Destroy(gameObject, 0);
        }
    }
}