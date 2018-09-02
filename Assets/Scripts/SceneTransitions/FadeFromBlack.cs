using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeFromBlack : MonoBehaviour
{
    protected SpriteRenderer sprite;
    protected float alpha;
    protected string nextScene;

    // Use this for initialization
    protected void Start()
    {
        IntializeComponents();
    }

    protected void Update()
    {
        DecreaseAlphaAndDestroy();
    }

    protected void IntializeComponents()
    {
        sprite = GetComponent<SpriteRenderer>();
        alpha = 1f;
    }

    protected void DecreaseAlphaAndDestroy()
    {
        alpha += -0.01f;
        sprite.color = new Color(0, 0, 0, alpha);

        if (alpha <= 0)
        {
            Destroy(gameObject, 0);
        }
    }
}
