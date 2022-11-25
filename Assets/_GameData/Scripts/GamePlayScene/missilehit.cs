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
        // targetobj.GetComponent<moveHorseSample>().speed = 0;
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        // targetobj.GetComponent<moveHorseSample>().speed = targetobj.GetComponent<moveHorseSample>().startspeed;
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        // targetobj.GetComponent<moveHorseSample>().speed = 0;
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        // targetobj.GetComponent<moveHorseSample>().speed = targetobj.GetComponent<moveHorseSample>().startspeed;
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        // targetobj.GetComponent<moveHorseSample>().speed = 0;
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        // targetobj.GetComponent<moveHorseSample>().speed = targetobj.GetComponent<moveHorseSample>().startspeed;
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(false);
        yield return new WaitForSeconds(.5f);
        targetobj.SetActive(true);
        targetobj.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        targetobj.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");

    }

}
