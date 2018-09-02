using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainActiveScript : MonoBehaviour {
    private SpriteRenderer sprite;
    private float opacity;
    public static RuneScriptRain rainRune;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        rainRune = RuneScriptRain.rune;
        opacity = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (rainRune.runeActive == true)
        {
            if (opacity <= 1)
            {
                opacity += 0.05f;
            } else
            {
                opacity = 1;
            }
        } else if (rainRune.runeActive == false)
        {
            if (opacity >= 0)
            {
                opacity += -0.05f;
            }
            else
            {
                opacity = 0;
                Destroy(gameObject, 0);
            }
        }
        
        
        sprite.color = new Color(1f, 1f, 1f, opacity);
	}
}
