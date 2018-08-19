using UnityEngine;

public abstract class RuneScript : MonoBehaviour {
    private string runeType;
    protected Animator anim;
    protected playerStats pS;
    private AudioSource sound;
    public bool runeActive;
    bool buttonState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }

    protected abstract string RuneType { get; }

    protected abstract void RuneAction();

    void Start() {
        pS = playerStats.stats;
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        anim.enabled = false;
        runeActive = false;
        runeType = RuneType;
    }

    // Update is called once per frame
    void Update() {
        if(anim.enabled == false) {
            checkUnlock();
        }

        anim.SetBool(runeType, true);
    }

    private void OnMouseDown() {
        if(buttonState(runeType)) {
            RuneAction();
            sound.Play();
        }
    }

    void checkUnlock() {
        if(pS.runeUnlockSpeed == true) {
            anim.enabled = true;
        }
    }

    void Reset() {
        runeActive = false;
        Invoke("CoolDown", pS.runeCoolDownSpeed);
    }

    void CoolDown() {
        anim.SetInteger("cooldown", 0);
    }
}