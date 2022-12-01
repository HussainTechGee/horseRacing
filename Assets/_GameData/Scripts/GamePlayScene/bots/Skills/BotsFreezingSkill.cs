using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsFreezingSkill : MonoBehaviour
{
    public static BotsFreezingSkill botsFreezingSkill;
    public BotPlyers bot1, bot2, bot3, bot4;
    public moveHorseSample player;
    public float freeztimer = 1, freecooldown = 5;
    public bool isfreez;
    private void Update()
    {
        if (isfreez)
        {
            freeztimer -= Time.deltaTime;
            freecooldown += Time.deltaTime;
        }
        if (freeztimer <= -1)
        {
            freeztimer = 1;
            player.freez = false;
            bot1.freez = false;
            bot2.freez = false;
            bot3.freez = false;
            bot4.freez = false;
            isfreez = false;

        }
        if (freecooldown >= 5)
        {

        }
    }
    public void freez()
    {
        {
            if (!player.shield)
            { player.freez = true; }
            if (!bot1.shield)
            { bot1.freez = true; }
            if (!bot2.shield)
            { bot2.freez = true; }
            if (!bot3.shield)
            { bot3.freez = true; }
            if (!bot4.shield)
            { bot4.freez = true; }
            isfreez = true;
            freecooldown = 0;
        }
    }
}
