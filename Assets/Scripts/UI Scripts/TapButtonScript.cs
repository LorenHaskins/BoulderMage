using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapButtonScript : MonoBehaviour
{
    public GameObject stationaryObjects;
    public Transform stationarySpawn;
    public GameObject SceneChoice; // Choose Prefab to the scene you're going to;

    private void OnMouseUp()
    {
        if (GameObject.FindWithTag("stationaryOpeningObject") == null)
        {
            Instantiate(stationaryObjects, stationarySpawn.position, stationarySpawn.rotation);
            Destroy(GameObject.Find("movingOpeningObjects"), 0);
        }
        else
        {
            ChooseSceneAndFade();
        }
    }

    void ChooseSceneAndFade()
    {
        Instantiate(SceneChoice, stationarySpawn.position, stationarySpawn.rotation);
    }
}
