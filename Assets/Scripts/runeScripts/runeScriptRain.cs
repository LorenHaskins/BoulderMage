using UnityEngine;

public class RuneScriptRain : RuneScript
{
    protected override string RuneType { get { return "rain"; } }
    protected override bool UnlockRune { get { return pS.runeUnlockRain; } }
    protected override int DurationTimer { get { return pS.runeDurationRain; } }
    protected override int CoolDownTimer { get { return pS.runeCoolDownRain; } }
    public static RuneScriptRain rune;
    public GameObject rainPrefab;
    public Transform rainSpawn;

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
        Debug.Log("Rain Rune AWAYYYY!!!");
        Instantiate(rainPrefab, rainSpawn.position, rainSpawn.rotation);
    }
}