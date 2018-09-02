using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToBlackScript : MonoBehaviour {
    public static FadeToBlackScript fade;
    protected SpriteRenderer sprite;
    protected float alpha;
    protected float alphaSpeed;
    protected string nextScene;

    // Use this for initialization
    protected void Start()
    {
        IntializeComponents();
    }

    protected void Update()
    {
        IncreaseAlphaChangeScene();
    }

    protected void PlayNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    protected void IntializeComponents()
    {
        sprite = GetComponent<SpriteRenderer>();
        alpha = 0f;
        alphaSpeed = 0.02f;
        sprite.enabled = true;
    }

    protected void IncreaseAlphaChangeScene()
    {
        
        alpha += alphaSpeed;
        sprite.color = new Color(0, 0, 0, alpha);

        if (alpha >= 1)
        {
            PlayNextScene();
        }
    }
}
