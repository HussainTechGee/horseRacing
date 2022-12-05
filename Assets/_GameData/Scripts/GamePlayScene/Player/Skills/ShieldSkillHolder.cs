using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkillHolder : MonoBehaviour
{
    public static ShieldSkillHolder instance;

    public float shieldtime = 5;
    bool isShield;
    public void onclickShield()
    {
        StopAllCoroutines();
        GetComponent<moveHorseSample>().shield = true;
        isShield = true;
        StartCoroutine(unApplyShield());
    }
    IEnumerator unApplyShield()
    {
        yield return new WaitForSeconds(shieldtime);
        if (isShield)
        {
            GetComponent<moveHorseSample>().shield = false;
            isShield = false;
        }
    }

}
