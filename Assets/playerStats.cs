using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {
    public float playerSpeedStat;
    public float playerExp;

	// Use this for initialization
	void Start ()
    {
        playerExp = 0f;
        playerSpeedStat = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("Give XP :" + playerExp);
    }
}
