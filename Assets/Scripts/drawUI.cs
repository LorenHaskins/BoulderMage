using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drawUI : MonoBehaviour
{
    public Text countText;
    public playerStats pS;

    // Use this for initialization
    void Start () {
        SetCoinCount();
        pS = playerStats.stats;
    }
	
	// Update is called once per frame
	void Update ()
    {
        SetCoinCount();
    }

    void SetCoinCount()
    {
        countText.text = pS.coinCount.ToString();       
    }
}
