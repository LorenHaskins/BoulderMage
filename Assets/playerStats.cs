using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerStats : MonoBehaviour {
    public static playerStats stats;
    public float playerSpeedStat;
    public float playerExp;
    public int playerLevel;
    public bool runeUnlockSpeed;
    public bool runeUnlockRain;
    public bool runeUnlockWind;
    public bool runeUnlockTime;
    public bool runeUnlockInv;
    public int runeCoolDownSpeed;
    public int runeCoolDownRain;
    public int runeCoolDownWind;
    public int runeCoolDownTime;
    public int runeCoolDownInv;
    public int runeDuractionSpeed;
    public int runeDurationRain;
    public int runeDurationWind;
    public int runeDurationTIme;
    public int runeDurationInv;
    public float runeMultiplyerSpeed;
    public float actualPlayerSpeed;
    public RuneScriptSpeed RuneScriptSpeed;
    public int coins;
    public float coinCount;

    // Use this for initialization
    void Awake()
    {
        //This allows this object to be the only object in existance
        if (stats == null)
        {
            DontDestroyOnLoad(gameObject);
            stats = this;
        } else if (stats != this)
        {
            Destroy(gameObject);
        }
    }


    void Start ()
    {
        playerLevel = 1;
        playerExp = 0f;
        playerSpeedStat = 1f;
        RuneScriptSpeed = RuneScriptSpeed.rune;
        coins = 5;


        //Speed Rune Stats
        runeCoolDownSpeed = 10;
        runeDuractionSpeed = 5;
        runeUnlockSpeed = true;
        runeMultiplyerSpeed = 5;

        //Wind Rune Stats
        runeCoolDownWind = 10;
        runeDurationWind = 5;
        runeUnlockWind = true;

        //Rain Rune Stats
        runeCoolDownRain = 10;
        runeDurationRain = 5;
        runeUnlockRain = true;

        //Time Rune Stats
        runeCoolDownTime = 10;
        runeDurationTIme = 5;
        runeUnlockTime = true;

        //Inv Rune Stats
        runeCoolDownInv = 10;
        runeDurationInv = 5;
        runeUnlockInv = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        actualPlayerSpeed = playerSpeedStat;

        if (RuneScriptSpeed.runeActive == true)
        {
            actualPlayerSpeed = playerSpeedStat + runeMultiplyerSpeed;
            
        }

        coinCount = coins;
    }
}
