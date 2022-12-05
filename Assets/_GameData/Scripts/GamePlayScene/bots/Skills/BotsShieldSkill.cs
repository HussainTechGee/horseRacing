using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsShieldSkill : MonoBehaviour
{
    public float shieldtime = 5;
    bool isShield;




    public void onclickShield()
    {
        this.StopAllCoroutines();
        GetComponent<BotPlyers>().shield = true;
        isShield = true;
        StartCoroutine(unApplySheild());
    }

    IEnumerator unApplySheild()
    {
        yield return new WaitForSeconds(shieldtime);
        if (isShield)
        {
            GetComponent<BotPlyers>().shield = false;
            isShield = false;
        }
    }
}
