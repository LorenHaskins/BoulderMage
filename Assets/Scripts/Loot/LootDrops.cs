using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootDrops : MonoBehaviour {
    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected playerStats pS;
    protected float horizVelocity;
    protected float vertVelocityMax;
    protected float vertVelocityMin;
    protected float destructOnCatch;
    public AudioSource[] sounds;
    public AudioSource soundBounce;
    public AudioSource soundGet;
    protected string lootType;
    protected abstract string LootType { get; }
    protected abstract int Value { get; }

    void Start() {
        ObjectComponents();
    }

    protected void ObjectComponents()
    {
        pS = playerStats.stats;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lootType = LootType;
        anim.SetTrigger(lootType);
        sounds = GetComponents<AudioSource>();
        soundBounce = sounds[1];
        soundGet = sounds[0];
        vertVelocityMin = 5f; //minimum jump on spawn
        vertVelocityMax = 8f; //maximum jump on spawn
        horizVelocity = 1.5f; //maximum and minimum left to right jump on spawn
        destructOnCatch = 0.5f; //time to disappear after catch
        rb2d.velocity = new Vector3(Random.Range(-horizVelocity, horizVelocity), Random.Range(vertVelocityMin, vertVelocityMax), 0);
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "boulder")
        {
            Debug.Log("Aww Yiss Mother Fuckin' Coin");
            anim.SetTrigger("catch");
            soundGet.Play();
            pS.coins += Value;
            Destroy(gameObject, destructOnCatch);
        }

        if (col.gameObject.tag == "ground")
        {
            soundBounce.Play();
        }
    }
}
