using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class finishcontroller : MonoBehaviour
{
    [SerializeField] int currentposition = 0;
    [SerializeField] GameObject fireworks;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "myfoot")
        {
            Time.timeScale = 1;
            fireworks.SetActive(true);
            cutSceneScript.instance.winpanel.transform.GetChild(0).gameObject.SetActive(false);
            cutSceneScript.instance.winpanel.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            if (other.transform.parent.GetComponent<ProgressManager>().position == 0)
            {
                currentposition++;
                other.transform.parent.GetComponent<ProgressManager>().position = currentposition;
            }
        }
    }
}
