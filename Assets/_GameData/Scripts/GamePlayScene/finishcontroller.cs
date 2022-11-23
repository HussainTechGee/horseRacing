using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishcontroller : MonoBehaviour
{

    int currentposition = 0;


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
