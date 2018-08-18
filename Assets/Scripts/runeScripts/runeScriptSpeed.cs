using UnityEngine;

public class RuneScriptSpeed : RuneScript
{
    protected override string RuneType { get { return "speed"; } }
    public static RuneScriptSpeed rune;

    // Use this for initialization
    void Awake() {
        //This allows this object to be the only object in existance
        if(rune == null) {
            rune = this;
        } else if(rune != this) {
            Destroy(gameObject);
        }
    }

    protected override void RuneAction() {
        Debug.Log("Speed Rune AWAYYYY!!!");
        anim.SetInteger("duration", pS.runeDuractionSpeed);
        anim.SetInteger("cooldown", pS.runeCoolDownSpeed);
        runeActive = true;
        Invoke("Reset", pS.runeDuractionSpeed);//this will happen after the length of the rune
    }
}
