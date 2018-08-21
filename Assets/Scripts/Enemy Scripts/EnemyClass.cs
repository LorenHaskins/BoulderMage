using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    protected Rigidbody2D rb2d; // Rigid Body reference
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

    public GameObject bronzeCoinPrefab;
    protected float bronzeDropChance; //Chance of ANY coins dropping
    protected int bronzeCoinDropRate; //How many coins drop. based on Max and Min
    protected int bronzeCoinMax;
    protected int bronzeCoinMin;

    public GameObject silverCoinPrefab;
    protected float silverDropChance; //Chance of ANY coins dropping
    protected int silverCoinDropRate; //How many coins drop. based on Max and Min
    protected int silverCoinMax;
    protected int silverCoinMin;

    public GameObject goldCoinPrefab;
    protected float goldDropChance; //Chance of ANY coins dropping
    protected int goldCoinDropRate; //How many coins drop. based on Max and Min
    protected int goldCoinMax;
    protected int goldCoinMin;

    public GameObject platinumCoinPrefab;
    protected float platinumDropChance; //Chance of ANY coins dropping
    protected int platinumCoinDropRate; //How many coins drop. based on Max and Min
    protected int platinumCoinMax;
    protected int platinumCoinMin;

    float roundToTenths(float x) { return (Mathf.Round(x * 10) / 10);}

    protected void ObjectComponents()
    {
        rb2d = GetComponent<Rigidbody2D>();
        boulder = boulderController.boulder;
        boulderCollider = boulder.GetComponent<CircleCollider2D>();
        selfCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        pS = playerStats.stats;
        hDirection = 0;

        dropRotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
    }

    protected void updateVariables() //Variables that need to update every single frame
    {
        whenDestroyed = animState("destroy");
        boulderLocation = roundToTenths(boulderCollider.bounds.center.x);
        selfLocation = roundToTenths(selfCollider.bounds.center.x);
    }



    protected void dropBronzeCoins()
    {
        var dropPercentage = Random.Range(0, 100);
        if (dropPercentage <= bronzeDropChance)
        {
        bronzeCoinDropRate = Random.Range(bronzeCoinMin, bronzeCoinMax);
        Debug.Log("Drop Bronze Coin!");
        // Create the Bullet from the Bullet Prefab
        for (var i = 0; i < bronzeCoinDropRate; i++)
            Instantiate(bronzeCoinPrefab, transform.position, dropRotation);
        }
    }

    protected void dropSilverCoins()
    {
        var dropPercentage = Random.Range(0, 100);
        if (dropPercentage <= silverDropChance)
        {
            silverCoinDropRate = Random.Range(silverCoinMin, silverCoinMax);
            Debug.Log("Drop Silver Coin!");
            // Create the Bullet from the Bullet Prefab
            for (var i = 0; i < silverCoinDropRate; i++)
                Instantiate(silverCoinPrefab, transform.position, dropRotation);
        }
    }

    protected void dropGoldCoins()
    {
        var dropPercentage = Random.Range(0, 100);
        if (dropPercentage <= goldDropChance)
        {
            goldCoinDropRate = Random.Range(goldCoinMin, goldCoinMax);
            Debug.Log("Drop Gold Coin!");
            // Create the Bullet from the Bullet Prefab
            for (var i = 0; i < goldCoinDropRate; i++)
                Instantiate(goldCoinPrefab, transform.position, dropRotation);
        }
    }

    protected void dropPlatinumCoins()
    {
        var dropPercentage = Random.Range(0, 100);
        if (dropPercentage <= platinumDropChance)
        {
            platinumCoinDropRate = Random.Range(platinumCoinMin, platinumCoinMax);
            Debug.Log("Drop Platinum Coin!");
            // Create the Bullet from the Bullet Prefab
            for (var i = 0; i < platinumCoinDropRate; i++)
                Instantiate(platinumCoinPrefab, transform.position, dropRotation);
        }
    }
}
