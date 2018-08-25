using UnityEngine;

public class RuneScriptSpeed : RuneScript
{
    protected override string RuneType { get { return "speed"; } }
    protected override bool UnlockRune { get { return pS.runeUnlockSpeed; } }
    protected override int DurationTimer { get { return pS.runeDurationSpeed; } }
    protected override int CoolDownTimer { get { return pS.runeCoolDownSpeed; } }
    public static RuneScriptSpeed rune;

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
        Debug.Log("Speed Rune AWAYYYY!!!");
    }
}