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
        else if (other.gameObject.CompareTag("rocketpick"))
        {
            BotsUsingSkills.botsUsingSkills.canuserocket = true;
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
            explosion.GetComponent<ParticleSystem>().Play();
            missilehit.instance.targetobj = gameObject.transform.parent.gameObject;
            missilehit.instance.rockethit = true;
            other.gameObject.transform.parent.gameObject.SetActive(false);
            // Destroy(other.gameObject.transform.parent.gameObject);

        }

    }
    private IEnumerator activeSkillPick(GameObject current)
    {
        yield return new WaitForSeconds(1f);
        current.gameObject.SetActive(true);
    }

    // IEnumerator explodeObject()
    // {
    //     yield return new WaitForSeconds(.5f);
    //     // gameObject.transform.parent.GetComponent<BotPlyers>().speed = 0;
    //     gameObject.transform.parent.gameObject.SetActive(false);

    //     yield return new WaitForSeconds(.5f);
    //     gameObject.transform.parent.gameObject.SetActive(true);
    //     gameObject.transform.parent.GetComponent<BotPlyers>().RiderController.SetTrigger("sprint");
    //     gameObject.transform.parent.GetComponent<BotPlyers>().botAnimator.SetTrigger("sprint");
    //     yield return new WaitForSeconds(.5f);
    //     gameObject.transform.parent.gameObject.SetActive(false);
    //     yield return new WaitForSeconds(.5f);
    //     gameObject.transform.parent.gameObject.SetActive(true);
    //     gameObject.transform.parent.GetComponent<BotPlyers>().RiderController.SetTrigger("sprint");
    //     gameObject.transform.parent.GetComponent<BotPlyers>().botAnimator.SetTrigger("sprint");

    // }
}
