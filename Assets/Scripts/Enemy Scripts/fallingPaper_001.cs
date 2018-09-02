using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPaper_001 : EnemyClass
{
    void Start () {
        hSpeed = 1f;
        worthXP = 1;

        //Chance is Probability, Min Max is how many if it happens
        bronzeDropChance = 100;
        bronzeCoinMin = 5;
        bronzeCoinMax = 5;
        //Chance is Probability, Min Max is how many if it happens
        silverDropChance = 0;
        silverCoinMax = 5;
        silverCoinMin = 5;
        //Chance is Probability, Min Max is how many if it happens
        goldDropChance = 0;
        goldCoinMax = 5;
        goldCoinMin = 5;
        //Chance is Probability, Min Max is how many if it happens
        platinumDropChance = 0;
        platinumCoinMax = 5;
        platinumCoinMin = 5;

        ObjectComponents();

    }

    // Update is called once per frame
    void Update()
    {
        updateVariables();
        uponDeath();
    }
}