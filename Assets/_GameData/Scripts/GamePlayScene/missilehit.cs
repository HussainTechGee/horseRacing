using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class missilehit : MonoBehaviour
{
    public static missilehit instance;
    public GameObject targetobj;
    public bool rockethit;
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (rockethit)
        {
            StartCoroutine(explodeObject());
            rockethit = false;
        }
    }
    public IEnumerator explodeObject()
    {

        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("death");
        if (targetobj.GetComponent<BotPlyers>() != null)
        {
            targetobj.GetComponent<BotPlyers>().speed *= 0;
        }
        else if (targetobj.GetComponent<moveHorseSample>() != null)
        {
            targetobj.GetComponent<moveHorseSample>().speed *= 0;
        }
        targetobj.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
        yield return new WaitForSeconds(2.7f);

        targetobj.SetActive(false);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("idle");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("idle");
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(true);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(true);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(true);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(true);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.3f);
        targetobj.SetActive(true);
        if (targetobj.GetComponent<BotPlyers>() != null)
        {
            targetobj.GetComponent<BotPlyers>().speed = targetobj.GetComponent<BotPlyers>().startSpeed;
        }
        else if (targetobj.GetComponent<moveHorseSample>() != null)
        {
            targetobj.GetComponent<moveHorseSample>().speed = targetobj.GetComponent<moveHorseSample>().startSpeed;
        }
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
    }
}
