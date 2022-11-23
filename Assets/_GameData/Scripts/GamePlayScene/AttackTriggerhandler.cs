using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerhandler : MonoBehaviour
{

    // public List<GameObject> targetObjects = new List<GameObject>();
    public GameObject targetobj;
    public Vector3 t;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {

            targetobj = other.gameObject;
            t = targetobj.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            targetobj = null;
        }
    }
}
