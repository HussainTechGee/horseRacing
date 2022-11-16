using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotsUsingSkills : MonoBehaviour
{

    public static BotsUsingSkills botsUsingSkills;
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
        float wait = Random.Range(5, 15);
        yield return new WaitForSeconds(wait);

        if (!GetComponent<BotsFreezingSkill>().isfreez)
        {
            GetComponent<BotsFreezingSkill>().freez();
        }

        if (!GetComponent<BotsBoostingSkill>().isboost)
        {
            GetComponent<BotsBoostingSkill>().boost();
        }
        StartCoroutine(useSkill());
    }
}
