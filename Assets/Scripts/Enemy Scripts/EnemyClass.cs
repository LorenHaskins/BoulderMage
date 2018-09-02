using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    protected Rigidbody2D rb2d; // Rigid Body reference
    protected SpriteRenderer spriteRend;
    protected float hDirection; //Horizontal direction
    public float hSpeed; //speed character can move on a horizontal plane
    public Animator anim; // Calls animator
    public CircleCollider2D boulderCollider;
    protected float boulderLocation;
    protected boulderController boulder;
    protected float selfLocation;
    public BoxCollider2D selfCollider;
    protected bool whenDestroyed;
    protected float worthXP;
    public float givePlayerExp;
    public playerStats pS;
    bool animState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }
    protected Quaternion dropRotation;
    public static RuneScriptTime timeRune;
    public GameObject timeActivatePrefab;
    protected GameObject lootDropPrefab;
    protected bool freezeTimeActive;
    protected float wetGrav;
    protected bool wet;

    protected int dropPercentage = 0;
    protected int lootDropChance = 0;
    protected int lootDropMin = 0;
    protected int lootDropMax = 0;

    public GameObject bronzeCoinPrefab;
    protected int bronzeDropChance; //Chance of ANY coins dropping
    protected int bronzeCoinDropRate; //How many coins drop. based on Max and Min
    protected int bronzeCoinMax;
    protected int bronzeCoinMin;

    public GameObject silverCoinPrefab;
    protected int silverDropChance; //Chance of ANY coins dropping
    protected int silverCoinDropRate; //How many coins drop. based on Max and Min
    protected int silverCoinMax;
    protected int silverCoinMin;

    public GameObject goldCoinPrefab;
    protected int goldDropChance; //Chance of ANY coins dropping
    protected int goldCoinDropRate; //How many coins drop. based on Max and Min
    protected int goldCoinMax;
    protected int goldCoinMin;

    public GameObject platinumCoinPrefab;
    protected int platinumDropChance; //Chance of ANY coins dropping
    protected int platinumCoinDropRate; //How many coins drop. based on Max and Min
    protected int platinumCoinMax;
    protected int platinumCoinMin;
    
    float roundToTenths(float x) { return (Mathf.Round(x * 10) / 10); }
       
    protected void ObjectComponents()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        boulder = boulderController.boulder;
        timeRune = RuneScriptTime.rune;
        boulderCollider = boulder.GetComponent<CircleCollider2D>();
        selfCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        pS = playerStats.stats;

        hDirection = 0;
        dropRotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        wetGrav = 2;
        wet = false;
    }

    protected void updateVariables() //Variables that need to update every single frame
    {
        whenDestroyed = animState("destroy");
        boulderLocation = roundToTenths(boulderCollider.bounds.center.x);
        selfLocation = roundToTenths(selfCollider.bounds.center.x);

        if (timeRune.runeActive == true)
        {
            if (freezeTimeActive == false)
            {
                freezeTime();
            }
            freezeObject();
        }
    }

    protected void dropLoot()
    {
        dropBronzeCoins();
        dropSilverCoins();
        dropGoldCoins();
        dropPlatinumCoins();
    }

    protected void dropSuccess()
    {
        if (dropPercentage <= lootDropChance)
        {
            var lootDropRate = Random.Range(lootDropMin, lootDropMax);
            Debug.Log("Drop " + lootDropRate + " Bronze Coins");
            for (var i = 0; i < lootDropRate; i++)
                Instantiate(lootDropPrefab, transform.position, dropRotation);
        }
    }

    protected void dropBronzeCoins()
    {
        dropPercentage = Random.Range(1, 101);
        lootDropChance = bronzeDropChance;
        lootDropMin = bronzeCoinMin;
        lootDropMax = bronzeCoinMax;
        lootDropPrefab = bronzeCoinPrefab;
        dropSuccess();
    }

    protected void dropSilverCoins()
    {
        dropPercentage = Random.Range(1, 101);
        lootDropChance = silverDropChance;
        lootDropMin = silverCoinMin;
        lootDropMax = silverCoinMax;
        lootDropPrefab = silverCoinPrefab;
        dropSuccess();
    }

    protected void dropGoldCoins()
    {
        dropPercentage = Random.Range(1, 101);
        lootDropChance = goldDropChance;
        lootDropMin = goldCoinMin;
        lootDropMax = goldCoinMax;
        lootDropPrefab = goldCoinPrefab;
        dropSuccess();
    }

    protected void dropPlatinumCoins()
    {
        dropPercentage = Random.Range(1, 101);
        lootDropChance = platinumDropChance;
        lootDropMin = platinumCoinMin;
        lootDropMax = platinumCoinMax;
        lootDropPrefab = platinumCoinPrefab;
        dropSuccess();
    }

    protected void freezeTime()
    {
        var zeroRotation = new Quaternion(0, 0, 0, 0);
        spriteRend.color = Color.blue;
        Invoke("unfreezeTime", timeRune.duration);
        Instantiate(timeActivatePrefab, transform.position, zeroRotation);
    }

    protected void freezeObject()
    {
        freezeTimeActive = true;
        var forceToAdd = new Vector3(0, 0, 0);
        rb2d.velocity = forceToAdd;
    }

    protected void unfreezeTime()
    {
        spriteRend.color = Color.white;
        freezeTimeActive = false;

    }

    protected void uponDeath()
    {
        if (whenDestroyed)
        {
            dropLoot();
            grantXP();
            destroyInstantly();
        }
    }

    protected void grantXP()
    {
        pS.playerExp += worthXP;
    }

    protected void destroyInstantly()
    {
        Destroy(gameObject, 0f);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "rain")
        {
            Debug.Log("Rain Hit");
            rb2d.gravityScale = wetGrav;
            anim.SetBool("wetGround", true);
            wet = true;
            rb2d.rotation = 0f;
        }
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "topGround")
        {
            if (wet == false)
            {
                if (selfLocation > boulderLocation)
                {
                    hDirection = -hSpeed;
                }
                else if (selfLocation < boulderLocation)
                {
                    hDirection = hSpeed;
                }

                rb2d.velocity = (transform.right * hSpeed * hDirection);
            }
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

        if (col.gameObject.tag == "deathSequence")
        {
            Destroy(gameObject, 0);
        }
    }
}
