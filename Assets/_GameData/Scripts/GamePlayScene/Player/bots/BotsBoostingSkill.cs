using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsBoostingSkill : MonoBehaviour
{
    public static BotsBoostingSkill botsBoostingSkill;
    public BotPlyers bot;
    public moveHorseSample player;
    public float boosttimer = 1;
    bool isboost;
    private void Update()
    {
        if (isboost)
        {
            boosttimer -= Time.deltaTime;
        }
        if (boosttimer <= -1)
        {
            boosttimer = 1;
            BotPlyers.instance.boost = false;
            isboost = false;
        }
    }
    public void boost()
    {
        BotPlyers.instance.boost = true;
        isboost = true;
    }
}
