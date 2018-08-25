using UnityEngine;

public class RuneScriptWind : RuneScript
{
    protected override string RuneType { get { return "wind"; } }
    protected override bool UnlockRune { get { return pS.runeUnlockWind; } }
    protected override int DurationTimer { get { return pS.runeDurationWind; } }
    protected override int CoolDownTimer { get { return pS.runeCoolDownWind; } }
    public static RuneScriptWind rune;
    public GameObject windPrefab;
    public Transform windSpawn;

    // Use this for initialization
    void Awake()
    {
        //This allows this object to be the only object in existance
        if (rune == null)
        {
            rune = this;
        }
        else if (rune != this)
        {
            Destroy(gameObject);
        }
    }

    protected override void RuneAction()
    {
        Debug.Log("Wind Rune AWAYYYY!!!");
        Instantiate(windPrefab, windSpawn.position, windSpawn.rotation);
    }
}