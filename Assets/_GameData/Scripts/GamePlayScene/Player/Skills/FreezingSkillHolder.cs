using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingSkillHolder : MonoBehaviour
{
    public static FreezingSkillHolder instance;
    public BotPlyers[] players;
    bool freez;
    public float freeztimer = 1f;
    public GameObject freezUI, icepartical;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
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

                if (!players[i].shield)
                { players[i].freez = true; }

            }
            freez = true;
        }
        StartCoroutine(freezUIA());
    }
    IEnumerator freezUIA()
    {
        GetComponent<moveHorseSample>().RiderController.SetTrigger("freez");
        icepartical.SetActive(true);

        yield return new WaitForSeconds(.5f);
        freezUI.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        freezUI.SetActive(false);
        icepartical.SetActive(false);
    }
}
