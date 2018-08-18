using UnityEngine;

public class RuneScriptSpeed : RuneScript
{
    protected override string RuneType { get { return "speed"; } }

    protected override void RuneAction() {
        Debug.Log("Speed Rune AWAYYYY!!!");
        anim.SetInteger("duration", pS.runeDuractionSpeed);
        anim.SetInteger("cooldown", pS.runeCoolDownSpeed);
        runeActive = true;
        Invoke("Reset", pS.runeDuractionSpeed);//this will happen after the length of the rune
    }
}
