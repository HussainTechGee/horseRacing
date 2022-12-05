using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsBoostingSkill : MonoBehaviour
{
    public static BotsBoostingSkill botsBoostingSkill;
    public float boosttimer = 2;
    public bool isboost;
    public void boost()
    {
        this.StopAllCoroutines();
        GetComponent<BotPlyers>().boost = true;
        isboost = true;
        StartCoroutine(stopBooster());
    }
    IEnumerator stopBooster()
    {
        yield return new WaitForSeconds(boosttimer);
        if (isboost)
        {
            GetComponent<BotPlyers>().boost = false;
            isboost = false;
        }
    }
}
