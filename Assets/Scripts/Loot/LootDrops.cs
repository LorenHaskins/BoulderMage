using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootDrops : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected playerStats pS;
    public AudioSource soundBounce;
    public AudioSource soundGet;

    private static readonly float horizVelocity = 1.5f; //maximum and minimum left to right jump on spawn
    private static readonly float vertVelocityMax = 8f; //maximum jump on spawn
    private static readonly float vertVelocityMin = 5f; //minimum jump on spawn
    private static readonly float destructOnCatch = 0.5f; //time to disappear after catch

    protected abstract string LootType { get; }
    protected abstract int Value { get; }

    protected int bronzeValue;
    protected int silverValue;
    protected int goldValue;
    protected int platinumValue;

    void Start()
    {
        ObjectComponents();
    }

    protected void ObjectComponents()
    {
        pS = playerStats.stats;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetTrigger(LootType);
        AudioSource[] sounds = GetComponents<AudioSource>();
        soundBounce = sounds[1];
        soundGet = sounds[0];
        rb2d.velocity = new Vector3(Random.Range(-horizVelocity, horizVelocity), Random.Range(vertVelocityMin, vertVelocityMax), 0);
        bronzeValue = 1;
        silverValue = 5;
        goldValue = 10;
        platinumValue = 25;
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