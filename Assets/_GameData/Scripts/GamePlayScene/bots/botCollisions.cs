using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botCollisions : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("freez"))
        {
            BotsUsingSkills.botsUsingSkills.canusefreezSkill = true;
            // StartCoroutine(gameObject.transform.parent.GetComponent<BotsUsingSkills>().useSkill());
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("boost"))
        {
            BotsUsingSkills.botsUsingSkills.canuseBoostSkill = true;
            // StartCoroutine(gameObject.transform.parent.GetComponent<BotsUsingSkills>().useSkill());
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("shield"))
        {
            BotsUsingSkills.botsUsingSkills.canuseshieldskill = true;
            // StartCoroutine(gameObject.transform.parent.GetComponent<BotsUsingSkills>().useSkill());
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("rocketpick"))
        {
            BotsUsingSkills.botsUsingSkills.canuserocket = true;
            // StartCoroutine(gameObject.transform.parent.GetComponent<BotsUsingSkills>().useSkill());
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            gameObject.transform.parent.GetComponent<BotPlyers>().win = true;
            StartCoroutine(gameObject.transform.parent.GetComponent<BotPlyers>().botWin());
        }
        else if (other.gameObject.CompareTag("rocket"))
        {
            Debug.Log(gameObject.transform.parent.name);
            Debug.Log("rockethit");
            explosion.SetActive(true);
            explosion.transform.GetChild(0).gameObject.SetActive(true);
            explosion.transform.GetChild(1).gameObject.SetActive(true);
            explosion.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            explosion.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            missilehit.instance.targetobj = gameObject.transform.parent.gameObject;
            missilehit.instance.explosion = explosion;
            missilehit.instance.rockethit = true;
            other.gameObject.transform.parent.gameObject.SetActive(false);

        }

    }
    private IEnumerator activeSkillPick(GameObject current)
    {
        yield return new WaitForSeconds(1f);
        current.gameObject.SetActive(true);
    }


}
