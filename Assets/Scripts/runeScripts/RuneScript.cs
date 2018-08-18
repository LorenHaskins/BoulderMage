using UnityEngine;

public abstract class RuneScript : MonoBehaviour {
    public static RuneScript rune;
    private string runeType;
    protected Animator anim;
    protected playerStats pS;
    public bool runeActive;
    bool buttonState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }

    protected abstract string RuneType { get; }

    protected abstract void RuneAction();

    // Use this for initialization
    void Awake() {
        //This allows this object to be the only object in existance
        if(rune == null) {
            rune = this;
        } else if(rune != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        pS = playerStats.stats;
        anim = GetComponent<Animator>();
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