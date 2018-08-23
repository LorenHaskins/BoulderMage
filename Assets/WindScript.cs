using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public playerStats pS;


	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        pS = playerStats.stats;
    }
	
	// Update is called once per frame
	void Update () {
        rb2d.velocity = (transform.up * 25);
        Destroy(gameObject, pS.runeDurationWind);
    }
}
