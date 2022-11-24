using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsUsingSkills : MonoBehaviour
{

    public static BotsUsingSkills botsUsingSkills;
    public bool canusefreezSkill, canuseBoostSkill, canuseshieldskill, canuserocket;

    // public float skillColldownTime;
    void Start()
    {
        if (botsUsingSkills == null)
        {
            botsUsingSkills = this;
        }
        StartCoroutine(useSkill());
    }
    private IEnumerator useSkill()
    {
        float wait = Random.Range(5, 10);

        yield return new WaitForSeconds(wait);
        if (canusefreezSkill)
        {
            if (!GetComponent<BotsFreezingSkill>().isfreez)
            {
                // yield return new WaitForSeconds(wait);
                GetComponent<BotsFreezingSkill>().freez();
                canusefreezSkill = false;
            }
        }
        else if (canuseBoostSkill)
        {
            if (!GetComponent<BotsBoostingSkill>().isboost)
            {
                // yield return new WaitForSeconds(wait);
                GetComponent<BotsBoostingSkill>().boost();
                canuseBoostSkill = false;
            }
        }
        else if (canuseshieldskill)
        {

            GetComponent<BotsShieldSkill>().onclickShield();
            canuseshieldskill = false;
        }
        else if (canuserocket)
        {
            GetComponent<MissileSkillHolder1>().onclickfire();
            canuserocket = false;
        }
        StartCoroutine(useSkill());
    }
}
