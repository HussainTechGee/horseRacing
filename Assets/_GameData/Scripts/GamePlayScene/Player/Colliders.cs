using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().win = true;
        }
        else if (other.gameObject.CompareTag("leftcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().turnright();
        }
        else if (other.gameObject.CompareTag("rightcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().turnleft();
        }
    }
}
