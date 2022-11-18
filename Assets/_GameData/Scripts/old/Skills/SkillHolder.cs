using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHolder : MonoBehaviour
{
    public Skills freezingskill, boostskill, destroyerSkill;
    float cooldowntime;
    float activetime;
    public bool useboostability, mainPlayer, canUseboostingSkill;
    public bool usefreezingability, canUsefreezingSkill;
    public bool canUseDestroyerability, usingDestroyer;
    bool usingboost, usingfreez;
    public GameObject freezingskillButton, boostskillbutton;
    enum freezskillstate
    {
        ready,
        active,
        cooldown

    }
    enum boostskillState
    {
        ready,
        active,
        cooldown
    }
    enum destroyerSkillState
    {
        ready,
        active,
        cooldown
    }
    freezskillstate freezingstate = freezskillstate.ready;
    boostskillState boostsingState = boostskillState.ready;
    destroyerSkillState destroyerState = destroyerSkillState.ready;
    private void Start()
    {
        canUsefreezingSkill = false;
        canUseboostingSkill = false;

    }
    void Update()
    {
        switch (freezingstate)
        {
            case freezskillstate.ready:
                if (gameObject.GetComponent<SkillHolder>().mainPlayer && gameObject.GetComponent<SkillHolder>().canUsefreezingSkill)
                    freezingskillButton.GetComponent<Button>().interactable = true;
                else if (gameObject.GetComponent<SkillHolder>().mainPlayer && !gameObject.GetComponent<SkillHolder>().canUsefreezingSkill)
                {
                    freezingskillButton.GetComponent<Button>().interactable = false;
                }
                if (usefreezingability)
                {
                    {
                        freezingskill.Activatefreez(gameObject);
                        freezingstate = freezskillstate.active;
                        activetime = freezingskill.activetimer;
                    }
                }
                break;
            case freezskillstate.active:
                if (activetime > 0)
                {
                    if (usefreezingability)
                    {
                        if (gameObject.GetComponent<SkillHolder>().mainPlayer && !gameObject.GetComponent<SkillHolder>().canUsefreezingSkill)
                            freezingskillButton.GetComponent<Button>().interactable = false;
                        usefreezingability = false;
                        usingfreez = true;
                    }
                    activetime -= Time.deltaTime;
                }
                else
                {
                    if (usingfreez)
                    {
                        freezingskill.BeginCooldownfreez(gameObject);
                        cooldowntime = freezingskill.cooldowntimer;
                        usingfreez = false;
                    }
                    freezingstate = freezskillstate.cooldown;
                }
                break;
            case freezskillstate.cooldown:
                if (cooldowntime > 0)
                {
                    cooldowntime -= Time.deltaTime;
                }
                else
                {
                    freezingstate = freezskillstate.ready;
                }
                break;
        }
        switch (boostsingState)
        {
            case boostskillState.ready:
                if (gameObject.GetComponent<SkillHolder>().mainPlayer && gameObject.GetComponent<SkillHolder>().canUseboostingSkill)
                    boostskillbutton.GetComponent<Button>().interactable = true;
                else if (gameObject.GetComponent<SkillHolder>().mainPlayer && !gameObject.GetComponent<SkillHolder>().canUseboostingSkill)
                    boostskillbutton.GetComponent<Button>().interactable = false;
                if (useboostability)
                {
                    boostskill.Activateboost(gameObject);
                    boostsingState = boostskillState.active;
                    activetime = boostskill.activetimer;
                }
                break;
            case boostskillState.active:
                if (activetime > 0)
                {
                    if (useboostability)
                    {
                        if (gameObject.GetComponent<SkillHolder>().mainPlayer && !gameObject.GetComponent<SkillHolder>().canUseboostingSkill)
                            boostskillbutton.GetComponent<Button>().interactable = false;
                        useboostability = false;
                        usingboost = true;
                    }
                    activetime -= Time.deltaTime;
                }
                else
                {
                    if (usingboost)
                    {
                        boostskill.BeginCooldownboost(gameObject);
                        cooldowntime = boostskill.cooldowntimer;
                        usingboost = false;
                    }
                    boostsingState = boostskillState.cooldown;
                }
                break;
            case boostskillState.cooldown:
                if (cooldowntime > 0)
                {
                    cooldowntime -= Time.deltaTime;
                }
                else
                {
                    boostsingState = boostskillState.ready;
                }
                break;
        }
        switch (destroyerState)
        {
            case destroyerSkillState.ready:

                if (canUseDestroyerability)
                {
                    destroyerSkill.ActivateDestroyer(gameObject);
                    destroyerState = destroyerSkillState.active;
                    activetime = destroyerSkill.activetimer;
                }

                break;
            case destroyerSkillState.active:
                if (activetime > 0)
                {
                    if (canUseDestroyerability)
                    {
                        canUseDestroyerability = false;
                        usingDestroyer = true;
                    }
                    activetime -= Time.deltaTime;
                }
                else
                {
                    if (usingDestroyer)
                    {
                        destroyerSkill.BeginCooldownDestroyer(gameObject);
                        cooldowntime = destroyerSkill.cooldowntimer;
                        usingDestroyer = false;
                    }
                    destroyerState = destroyerSkillState.cooldown;
                }

                break;
            case destroyerSkillState.cooldown:
                if (cooldowntime > 0)
                {
                    cooldowntime -= Time.deltaTime;
                }
                else
                {
                    destroyerState = destroyerSkillState.ready;
                }
                break;
        }

    }
    public void onfreezButtonClick()
    {
        if (canUsefreezingSkill)
        {
            usefreezingability = true;
            canUsefreezingSkill = false;
        }
    }
    public void onBoostButtonClick()
    {
        if (canUseboostingSkill)
        {
            useboostability = true;
            canUseboostingSkill = false;
        }
    }
    public void onDestroyClick()
    {
        gameObject.GetComponent<PlayerScript>().destroyOthers = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "freez")
        {
            canUsefreezingSkill = true;
        }
        else if (other.gameObject.tag == "boost")
        {
            canUseboostingSkill = true;
        }
        else if (other.gameObject.tag == "destroy")
        {
            Debug.Log(gameObject.name);
            canUseDestroyerability = true;
            Destroy(other.gameObject, 0.3f);

        }
    }
}
