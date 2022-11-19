using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            gameObject.transform.parent.GetComponent<BotPlyers>().win = true;
        }
        else if (other.gameObject.CompareTag("freez"))
        {
            BotsUsingSkills.botsUsingSkills.canusefreezSkill = true;
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("boost"))
        {
            BotsUsingSkills.botsUsingSkills.canuseBoostSkill = true;
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("shield"))
        {
            BotsUsingSkills.botsUsingSkills.canuseshieldskill = true;
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
    }
    private IEnumerator activeSkillPick(GameObject current)
    {
        yield return new WaitForSeconds(1f);
        current.gameObject.SetActive(true);
    }
}
