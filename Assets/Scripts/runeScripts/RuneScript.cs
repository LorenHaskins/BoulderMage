using UnityEngine;

public abstract class RuneScript : MonoBehaviour
{
    private string runeType;
    protected Animator anim;
    protected playerStats pS;
    private AudioSource sound;
    public bool runeActive;
    bool buttonState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }
        
    protected abstract string RuneType { get; }
    protected abstract bool UnlockRune { get; }
    protected abstract int DurationTimer { get; }
    protected abstract int CoolDownTimer { get; }

    protected abstract void RuneAction();

    void Start()
    {
        pS = playerStats.stats;
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        anim.enabled = false;
        runeActive = false;
        runeType = RuneType;
        
    }

    // Update is called once per frame
    void Update()
    {
         if (UnlockRune == true)
        {
            anim.enabled = true;
            anim.SetBool(RuneType, true);
        }
    }

    private void OnMouseDown()
    {
        if (buttonState(runeType))
        {
            RuneAction();
            UniversalRuneActions();
            sound.Play();
        }
    }

    protected void UniversalRuneActions()
    {
        anim.SetInteger("duration", DurationTimer);
        anim.SetInteger("cooldown", CoolDownTimer);
        runeActive = true;
        Invoke("Reset", DurationTimer);//this will happen after the length of the rune
    }

    void Reset()
    {
        runeActive = false;
        Invoke("CoolDown", CoolDownTimer);
    }

    void CoolDown()
    {
        anim.SetInteger("cooldown", 0);
    }
}