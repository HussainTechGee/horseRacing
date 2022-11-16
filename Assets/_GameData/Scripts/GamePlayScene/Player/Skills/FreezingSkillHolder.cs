using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingSkillHolder : MonoBehaviour
{
    public BotPlyers[] players;
    bool freez;
    public float freeztimer = 1f;

    private void Start()
    {

    }
    private void Update()
    {
        if (freez)
        {
            freeztimer -= Time.deltaTime;
        }
        if (freeztimer <= -1)
        {
            if (freez)
            {
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].freez = false;
                }
                freez = false;
                freeztimer = 1f;
            }
        }
    }

    public void onfreezClick()
    {
        if (!freez)
        {
            for (int i = 0; i < players.Length; i++)
            {

                players[i].freez = true;

            }
            freez = true;
        }
    }
}
