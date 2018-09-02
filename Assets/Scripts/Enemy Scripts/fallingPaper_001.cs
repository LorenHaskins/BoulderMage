using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPaper_001 : EnemyClass {
    void Start () {
        hSpeed = 1f;
        worthXP = 1;

        //Possible Loot
        Loot bronzeLoot = new Loot("bronzeCoinPrefab", 100, 5, 5);
        Loot silverLoot = new Loot("silverCoinPrefab", 100, 3, 3);
        Loot goldLoot = new Loot("goldCoinPrefab", 100, 2, 2);
        Loot platLoot = new Loot("platinumCoinPrefab", 100, 1, 1);

        loots = new List<Loot> {
            bronzeLoot,
            //silverLoot,
            //goldLoot,
            //platLoot
        };

        ObjectComponents();
    }

    // Update is called once per frame
    void Update()
    {
        updateVariables();
        uponDeath();
    }
}