using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerandler : MonoBehaviour
{
    private bool isintrigger, isempty;
    public GameObject targetobject;
    private void Start()
    {
        isintrigger = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        // if (!isintrigger)
        {
            if (other.gameObject.CompareTag("Animal"))
            {
                targetobject = other.gameObject;
                // isintrigger = true;
            }
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (isintrigger)
    //     {
    //         if (other.gameObject.CompareTag("Animal"))
    //         {

    //             if (other.gameObject.name == targetobject.name)
    //             {
    //                 targetobject = null;
    //                 isintrigger = false;
    //             }
    //             else
    //             {
    //                 targetobject = null;
    //                 isintrigger = false;
    //             }
    //         }
    //     }
    // }
    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.gameObject.tag != "Animal")
    //     {
    //         targetobject = null;
    //         isintrigger = false;
    //     }
    // }

}
