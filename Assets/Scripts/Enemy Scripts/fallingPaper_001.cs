using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPaper_001 : EnemyClass
{
    // Use this for initialization
    void Start () {
        hSpeed = 1f;

        worthXP = 1;

        //Chance is Probability, Min Max is how many if it happens
        bronzeDropChance = 100;
        bronzeCoinMin = 5;
        bronzeCoinMax = 5;
        //Chance is Probability, Min Max is how many if it happens
        silverDropChance = 100;
        silverCoinMax = 5;
        silverCoinMin = 5;
        //Chance is Probability, Min Max is how many if it happens
        goldDropChance = 100;
        goldCoinMax = 5;
        goldCoinMin = 5;
        //Chance is Probability, Min Max is how many if it happens
        platinumDropChance = 100;
        platinumCoinMax = 50;
        platinumCoinMin = 50;

        ObjectComponents();
    }
	
	// Update is called once per frame
	void Update ()
    {
        updateVariables();

        if (whenDestroyed)
        {
            dropLoot();
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
                hDirection = -hSpeed;
            }
            else if (selfLocation < boulderLocation)
            {
                hDirection = hSpeed;
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

    void dropLoot()
    {
        dropBronzeCoins();
        dropSilverCoins();
        dropGoldCoins();
        dropPlatinumCoins();
    }
}