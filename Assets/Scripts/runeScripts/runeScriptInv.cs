using UnityEngine;

public class RuneScriptInv : RuneScript
{
    protected override string RuneType { get { return "inv"; } }
    protected override bool UnlockRune { get { return pS.runeUnlockInv; } }
    protected override int DurationTimer { get { return pS.runeDurationInv; } }
    protected override int CoolDownTimer { get { return pS.runeCoolDownInv; } }
    bool buttonState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }
    public static RuneScriptInv rune;
    public GameObject InvBarrierPrefab;
    public Transform InvBarrierSpawn;
    public bool activate;

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
        Debug.Log("Inv Rune AWAYYYY!!!");
        
        Instantiate(InvBarrierPrefab, InvBarrierSpawn.position, InvBarrierSpawn.rotation);
        activate = true;
        Invoke("Destruction", DurationTimer);//this will happen after the length of the rune
        
    }

    void Destruction()
    {
        activate = false;
    }
}