using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsBoostingSkill : MonoBehaviour
{
    public static BotsBoostingSkill botsBoostingSkill;
    public float boosttimer = 1;
    public bool isboost;
    private void Update()
    {
        if (isboost)
        {
            boosttimer -= Time.deltaTime;
        }
        if (boosttimer <= -1)
        {
            boosttimer = 1;
            GetComponent<BotPlyers>().boost = false;

            isboost = false;
        }
    }
    public void boost()
    {
        GetComponent<BotPlyers>().boost = true;
        isboost = true;
    }
}
