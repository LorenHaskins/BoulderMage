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
    bool AnimState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }
    protected Quaternion dropRotation;
    public static RuneScriptTime timeRune;
    public GameObject timeActivatePrefab;
    protected bool freezeTimeActive;
    protected float wetGrav;
    protected bool wet;

    public struct Loot {
        public Loot(string prefabName, int dropChance, int dropMax, int dropMin) {
            this.prefabName = prefabName;
            this.dropChance = dropChance;
            this.dropMax = dropMax;
            this.dropMin = dropMin;
        }

        public string prefabName;
        public int dropChance;
        public int dropMax;
        public int dropMin;
    }

    protected List<Loot> loots;
    
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
        whenDestroyed = AnimState("destroy");
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

    protected void dropLoot() {
        foreach(Loot loot in this.loots) {
            dropSuccess(loot);
        }
    }

    protected void dropSuccess(Loot loot) 
    {
        int dropPercentage = Random.Range(1, 101);
        if (dropPercentage <= loot.dropChance)
        {
            var lootDropRate = Random.Range(loot.dropMin, loot.dropMax + 1);  //How many coins drop. based on Max and Min
            Debug.Log("Drop " + lootDropRate + " Bronze Coins");
            for (var i = 0; i < lootDropRate; i++)
                Instantiate(Resources.Load(loot.prefabName), transform.position, dropRotation);
        }
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
