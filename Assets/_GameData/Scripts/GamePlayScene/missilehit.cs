using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class missilehit : MonoBehaviour
{
    public static missilehit instance;
    public GameObject targetobj, explosion;
    public bool rockethit;
    bool isshield, isfreez;
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (rockethit)
        {
            StartCoroutine(explodeObject(targetobj, explosion));
            rockethit = false;
        }
    }
    public IEnumerator explodeObject(GameObject target, GameObject explo)
    {
        if (target.GetComponent<BotPlyers>() != null)
        {
            isshield = target.GetComponent<BotPlyers>().shield;
            isfreez = target.GetComponent<BotPlyers>().freez;

        }
        else if (target.GetComponent<moveHorseSample>() != null)
        {
            isshield = target.GetComponent<moveHorseSample>().shield;
            isfreez = target.GetComponent<moveHorseSample>().freez;
        }
        if (!isshield && !isfreez)
        {
            target.transform.GetChild(0).GetComponent<Animator>().SetTrigger("death");
            if (target.GetComponent<BotPlyers>() != null)
            {
                target.GetComponent<BotPlyers>().speed *= 0;
            }
            else if (target.GetComponent<moveHorseSample>() != null)
            {
                target.GetComponent<moveHorseSample>().speed *= 0;
            }
            target.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
            yield return new WaitForSeconds(2.7f);
            explo.SetActive(false);
            target.transform.GetChild(0).GetChild(9).gameObject.SetActive(false);
            target.SetActive(false);
            yield return new WaitForSeconds(.3f);
            target.SetActive(true);
            target.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
            target.transform.GetChild(0).GetComponent<Animator>().SetTrigger("idle");
            target.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("idle");
            yield return new WaitForSeconds(.3f);
            target.SetActive(false);
            yield return new WaitForSeconds(.3f);
            target.SetActive(true);
            yield return new WaitForSeconds(.3f);
            target.SetActive(false);
            yield return new WaitForSeconds(.3f);
            target.SetActive(true);
            yield return new WaitForSeconds(.3f);
            target.SetActive(false);
            yield return new WaitForSeconds(.3f);
            target.SetActive(true);
            yield return new WaitForSeconds(.3f);
            target.SetActive(false);
            yield return new WaitForSeconds(.3f);
            target.SetActive(true);
            yield return new WaitForSeconds(.3f);
            target.SetActive(false);
            yield return new WaitForSeconds(.3f);
            target.SetActive(true);
            if (target.GetComponent<BotPlyers>() != null)
            {
                target.GetComponent<BotPlyers>().speed = target.GetComponent<BotPlyers>().startSpeed;
            }
            else if (target.GetComponent<moveHorseSample>() != null)
            {
                target.GetComponent<moveHorseSample>().speed = target.GetComponent<moveHorseSample>().startSpeed;
            }
            target.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
            target.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
            isshield = false;
            isfreez = false;
        }
        yield return new WaitForSeconds(1f);
        targetobj = null;
    }
}
