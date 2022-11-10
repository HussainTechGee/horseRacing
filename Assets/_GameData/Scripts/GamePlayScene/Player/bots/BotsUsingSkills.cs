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
        yield return new WaitForSeconds(5f);

        if (!GetComponent<BotsFreezingSkill>().isfreez)
        {
            GetComponent<BotsFreezingSkill>().freez();
        }
        StartCoroutine(useSkill());
    }
}
