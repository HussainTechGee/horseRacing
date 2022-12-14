using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefinish : MonoBehaviour
{
    private void Start()
    {
        GetComponent<LineRenderer>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("foot"))
        {
            StartCoroutine(cutSceneScript.instance.onWin());
            transform.parent.GetChild(0).gameObject.SetActive(false);
            GetComponent<LineRenderer>().enabled = true;

        }
    }
}
