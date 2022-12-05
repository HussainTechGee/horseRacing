using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsFreezingSkill : MonoBehaviour
{
    public static BotsFreezingSkill botsFreezingSkill;
    public BotPlyers bot1, bot2, bot3, bot4;
    public moveHorseSample player;
    public float freeztimer = 2.5f;
    public bool isfreez;
    public void freez()
    {
        this.StopAllCoroutines();
        if (!player.shield)
        {
            player.freez = true;
            StartCoroutine(player.GetComponent<FreezingSkillHolder>().freezUIA());
        }
        if (!bot1.shield)
        { bot1.freez = true; }
        if (!bot2.shield)
        { bot2.freez = true; }
        if (!bot3.shield)
        { bot3.freez = true; }
        if (!bot4.shield)
        { bot4.freez = true; }
        isfreez = true;

        this.StartCoroutine(unfreezAll());
    }
    IEnumerator unfreezAll()
    {
        yield return new WaitForSeconds(freeztimer);
        if (isfreez)
        {
            freeztimer = 1;
            player.freez = false;
            bot1.freez = false;
            bot2.freez = false;
            bot3.freez = false;
            bot4.freez = false;
            isfreez = false;
        }
    }
}
