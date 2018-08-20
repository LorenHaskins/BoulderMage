using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private CircleCollider2D col;
    private Animator anim;
    public int value;
    private float horizVelocity;
    private float vertVelocityMax;
    private float vertVelocityMin;
    private float destructionTime;
    bool animState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }

    public AudioSource[] sounds;
    public AudioSource soundCoinBounce;
    public AudioSource soundCoinGet;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        destructionTime = 0.5f;
        value = 1;
        horizVelocity = 1.5f;
        vertVelocityMin = 5f;
        vertVelocityMax = 8f;
        rb2d.velocity = new Vector3(Random.Range(-horizVelocity, horizVelocity), Random.Range(vertVelocityMin, vertVelocityMax), 0);
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);

        sounds = GetComponents<AudioSource>();
        soundCoinBounce = sounds[1];
        soundCoinGet = sounds[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "boulder")
        {
            Debug.Log("Aww Yiss Mother Fuckin' Coins");
            anim.SetTrigger("catch");
            soundCoinGet.Play();
            Destroy(gameObject, destructionTime);
        }

        if (col.gameObject.tag == "ground")
        {
            soundCoinBounce.Play();
        }
    }


}