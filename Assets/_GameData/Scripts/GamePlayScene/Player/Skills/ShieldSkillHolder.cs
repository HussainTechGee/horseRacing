using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkillHolder : MonoBehaviour
{
    public static ShieldSkillHolder instance;

    public float shieldtime = 1, shieldcooldowntime = 5;
    bool isShield;

    private void Update()
    {
        if (isShield)
        {
            shieldtime -= Time.deltaTime;
            shieldcooldowntime += Time.deltaTime;
        }
        if (shieldtime <= -1)
        {
            shieldtime = 1;
            GetComponent<moveHorseSample>().shield = false;

            isShield = false;
        }
    }


    public void onclickShield()
    {
        GetComponent<moveHorseSample>().shield = true;
        isShield = true;
    }

}
