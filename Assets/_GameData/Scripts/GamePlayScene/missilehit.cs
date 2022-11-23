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

        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.GetComponent<BotPlyers>().RiderController.SetTrigger("sprint");
        targetobj.GetComponent<BotPlyers>().botAnimator.SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.GetComponent<BotPlyers>().RiderController.SetTrigger("sprint");
        targetobj.GetComponent<BotPlyers>().botAnimator.SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.GetComponent<BotPlyers>().RiderController.SetTrigger("sprint");
        targetobj.GetComponent<BotPlyers>().botAnimator.SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.GetComponent<BotPlyers>().RiderController.SetTrigger("sprint");
        targetobj.GetComponent<BotPlyers>().botAnimator.SetTrigger("sprint");

    }

}
