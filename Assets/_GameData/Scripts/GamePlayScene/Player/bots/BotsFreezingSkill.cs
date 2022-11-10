using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsFreezingSkill : MonoBehaviour
{
    public BotPlyers bot;
    public moveHorseSample player;
    public float freeztimer = 1;
    bool isfreez;
    void Start()
    {

    }


    void Update()
    {

    }
    void freez()
    {
        player.freez = true;
        bot.freez = true;
    }
}
