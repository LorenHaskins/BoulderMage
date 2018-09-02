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
    public int runeDurationSpeed;
    public int runeDurationRain;
    public int runeDurationWind;
    public int runeDurationTime;
    public int runeDurationInv;
    public float runeMultiplyerSpeed;
    public float actualPlayerSpeed;
    public RuneScriptSpeed RuneScriptSpeed;
    public int coins;
    public float coinCount;
    public int lives;

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
        lives = 3;


        //Speed Rune Stats
        runeCoolDownSpeed = 10;
        runeDurationSpeed = 2;
        runeUnlockSpeed = true;
        runeMultiplyerSpeed = 5;

        //Rain Rune Stats
        runeCoolDownRain = 10;
        runeDurationRain = 2;
        runeUnlockRain = true;

        //Wind Rune Stats
        runeCoolDownWind = 10;
        runeDurationWind = 2;
        runeUnlockWind = true;

        //Time Rune Stats
        runeCoolDownTime = 10;
        runeDurationTime = 2;
        runeUnlockTime = true;

        //Inv Rune Stats
        runeCoolDownInv = 10;
        runeDurationInv =10;
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
