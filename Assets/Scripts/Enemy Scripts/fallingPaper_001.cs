using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPaper_001 : MonoBehaviour {

    public Rigidbody2D rb2d; // Rigid Body reference
    private float hDirection; //Horizontal direction
    public float hSpeed; //speed character can move on a horizontal plane
    public Animator anim; // Calls animator
    public CircleCollider2D boulderCollider;
    private float boulderLocation;
    private boulderController boulder;
    private float selfLocation;
    public BoxCollider2D selfCollider;
    private staffController staff;
    private BoxCollider2D staffCollider;
    private bool whenDestroyed;
    private float worthXP;
    public float givePlayerExp;
    public playerStats pS;
    public GameObject bronzeCoinPrefab;
    private Quaternion dropRotation;
    private int bronzeCoinChance;
    private int maxBronzeCoins;
    private int minBronzeCoins;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        boulder = boulderController.boulder;
        boulderCollider = boulder.GetComponent<CircleCollider2D>();
        hSpeed = 1f;
        hDirection = 0;
        selfCollider = GetComponent<BoxCollider2D>();
        staff = staffController.staff;
        staffCollider = staff.GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        pS = playerStats.stats;
        worthXP = 1;
        minBronzeCoins = 0;
        maxBronzeCoins = 5;
        bronzeCoinChance = Random.Range(minBronzeCoins, maxBronzeCoins);
        dropRotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
    }
	
	// Update is called once per frame
	void Update ()
    {
        updateVariables();

        if (whenDestroyed)
        {
            dropCoin();
            pS.playerExp += worthXP;
            Destroy(gameObject, 0f);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "topGround")
        {
            if (selfLocation > boulderLocation)
            {
                hDirection = -1;
            }
            else if (selfLocation < boulderLocation)
            {
                hDirection = 1;
            }
            rb2d.velocity = (transform.right * hSpeed * hDirection);
        }

        if (col.gameObject.tag == "aura")
        {
            Debug.Log("HIT WITH AURA");
            anim.SetTrigger("hitAura");
        }

        if (col.gameObject.tag == "lightning")
        {
            Debug.Log("HIT WITH LIGHTNING");
            anim.SetTrigger("hitLightning");
        }
    }

    void updateVariables() //Variables that need to update every single frame
    {
        whenDestroyed = anim.GetCurrentAnimatorStateInfo(0).IsName("destroy");
        boulderLocation = (Mathf.Round(boulderCollider.bounds.center.x * 100) / 100);
        selfLocation = (Mathf.Round(selfCollider.bounds.center.x * 100) / 100);

    }

    void dropCoin()
    {
        Debug.Log("Drop Bronze Coin!");
        // Create the Bullet from the Bullet Prefab
        for (var i = 0; i < bronzeCoinChance; i++)
            Instantiate(bronzeCoinPrefab,transform.position,dropRotation);

    }

}