using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsFreezingSkill : MonoBehaviour
{
    public static BotsFreezingSkill botsFreezingSkill;
    public BotPlyers bot;
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
            bot.freez = false;

        }
        if (freecooldown >= 5)
        {
            isfreez = false;
        }
    }
    public void freez()
    {
        {
            player.freez = true;
            bot.freez = true;
            isfreez = true;
            freecooldown = 0;
        }
    }
}
