using UnityEngine;

public class RuneScriptTime : RuneScript
{
    protected override string RuneType { get { return "time"; } }
    protected override bool UnlockRune { get { return pS.runeUnlockTime; } }
    protected override int DurationTimer { get { return pS.runeDurationTime; } }
    protected override int CoolDownTimer { get { return pS.runeCoolDownTime; } }
    public static RuneScriptTime rune;

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
        Debug.Log("Time Rune AWAYYYY!!!");
    }
}