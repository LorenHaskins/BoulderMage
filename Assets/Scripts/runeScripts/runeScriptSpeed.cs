using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeScriptSpeed : MonoBehaviour
{
    public static runeScriptSpeed speedRune;
    private string runeType;
    private Animator anim;
    private playerStats pS;
    public bool runeActive;
    bool buttonState(string state) { return anim.GetCurrentAnimatorStateInfo(0).IsName(state); }

    // Use this for initialization
    void Awake()
    {
        //This allows this object to be the only object in existance
        if (speedRune == null)
        {
            speedRune = this;
        }
        else if (speedRune != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        pS = playerStats.stats;
        anim = GetComponent<Animator>();
        anim.enabled = false;
        runeActive = false;
        runeType = "speed";
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.enabled == false)
        {
            checkUnlock();
        }

        anim.SetBool(runeType, true);
    }

    private void OnMouseDown()
    {
        if (buttonState(runeType))
        {
            runeAction();
        }
    }

    void checkUnlock()
    {
            if (pS.runeUnlockSpeed == true)
            {
                anim.enabled = true;
            }
    }

    void runeAction()
    {
        Debug.Log("Speed Rune AWAYYYY!!!");
        anim.SetInteger("duration", pS.runeDuractionSpeed);
        anim.SetInteger("cooldown", pS.runeCoolDownSpeed);
        runeActive = true;
        Invoke("Reset", pS.runeDuractionSpeed);//this will happen after the length of the rune
    }

    void Reset()
    {
        runeActive = false;
        Invoke("CoolDown", pS.runeCoolDownSpeed);
    }

    void CoolDown()
    {
        anim.SetInteger("cooldown", 0);
    }
}
