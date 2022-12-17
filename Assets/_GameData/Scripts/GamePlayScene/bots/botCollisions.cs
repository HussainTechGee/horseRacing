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
            gameObject.transform.parent.GetComponent<BotsUsingSkills>().canusefreezSkill = true;
            StartCoroutine(gameObject.transform.parent.GetComponent<BotsUsingSkills>().useSkill());
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("boost"))
        {
            gameObject.transform.parent.GetComponent<BotsUsingSkills>().canuseBoostSkill = true;
            StartCoroutine(gameObject.transform.parent.GetComponent<BotsUsingSkills>().useSkill());
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("shield"))
        {
            gameObject.transform.parent.GetComponent<BotsUsingSkills>().canuseshieldskill = true;
            StartCoroutine(gameObject.transform.parent.GetComponent<BotsUsingSkills>().useSkill());
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("rocketpick"))
        {
            gameObject.transform.parent.GetComponent<BotsUsingSkills>().canuserocket = true;
            StartCoroutine(gameObject.transform.parent.GetComponent<BotsUsingSkills>().useSkill());
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject));
        }
        else if (other.gameObject.CompareTag("fence"))
        {

            if (!transform.parent.GetComponent<BotPlyers>().missilehit)
            {
                gameObject.transform.parent.GetComponent<BotPlyers>().botAnimator.SetTrigger("jump");
                gameObject.transform.parent.GetComponent<BotPlyers>().RiderController.SetTrigger("jump");
                missilehit.instance.targetobj = gameObject.transform.parent.gameObject;
                missilehit.instance.explosion = explosion;
                missilehit.instance.rockethit = true;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(activatecollider(other.gameObject, .5f));
            }
        }

    }
    IEnumerator activatecollider(GameObject current, float duration)
    {
        yield return new WaitForSeconds(duration);
        current.GetComponent<BoxCollider>().enabled = true;
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
            // Debug.Log(gameObject.transform.parent.name);
            // Debug.Log("rockethit");

            if (!transform.parent.GetComponent<BotPlyers>().missilehit && !transform.parent.GetComponent<BotPlyers>().shield)
            {
                transform.parent.GetComponent<BotPlyers>().missilehit = true;
                explosion.SetActive(true);
                explosion.transform.GetChild(0).gameObject.SetActive(true);
                explosion.transform.GetChild(1).gameObject.SetActive(true);
                explosion.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                explosion.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
                missilehit.instance.targetobj = gameObject.transform.parent.gameObject;
                missilehit.instance.explosion = explosion;
                missilehit.instance.rockethit = true;
            }
            other.gameObject.transform.parent.gameObject.SetActive(false);

        }

    }
    private IEnumerator activeSkillPick(GameObject current)
    {
        yield return new WaitForSeconds(1f);
        current.gameObject.SetActive(true);
    }


}
