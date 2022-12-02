using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsUsingSkills : MonoBehaviour
{

    public static BotsUsingSkills botsUsingSkills;
    public bool canusefreezSkill, canuseBoostSkill, canuseshieldskill, canuserocket;

    // public float skillColldownTime;
    private void Awake()
    {
        botsUsingSkills = this;
    }
    public IEnumerator useSkill()
    {
        float wait = Random.Range(3, 10);

        yield return new WaitForSeconds(wait);
        if (canusefreezSkill)
        {
            if (!GetComponent<BotsFreezingSkill>().isfreez)
            {
                GetComponent<BotsFreezingSkill>().freez();
                canusefreezSkill = false;
                Debug.LogError(gameObject.name + "usingfreez");
            }
        }
        else if (canuseBoostSkill)
        {
            if (!GetComponent<BotsBoostingSkill>().isboost)
            {
                GetComponent<BotsBoostingSkill>().boost();
                canuseBoostSkill = false;
                Debug.LogError(gameObject.name + "usingboost");
            }
        }
        else if (canuseshieldskill)
        {

            GetComponent<BotsShieldSkill>().onclickShield();
            canuseshieldskill = false;
            Debug.LogError(gameObject.name + "usingshield");
        }
        else if (canuserocket)
        {
            GetComponent<horse_distance>().onClickFire();
            canuserocket = false;
        }
    }
}
