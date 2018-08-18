using UnityEngine;

public class RuneScriptWind : RuneScript {
    protected override string RuneType { get { return "wind"; } }

    protected override void RuneAction() {
        Debug.Log("Rain Rune AWAYYYY!!!");
        anim.SetInteger("duration", pS.runeDuractionSpeed);
        anim.SetInteger("cooldown", pS.runeCoolDownSpeed);
        runeActive = true;
        Invoke("Reset", pS.runeDuractionSpeed);//this will happen after the length of the rune
    }
}