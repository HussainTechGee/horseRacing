using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("leftcol"))
        {
            gameObject.transform.parent.parent.GetComponent<moveHorseSample>().turnright(1.2f);
        }
        else if (other.gameObject.CompareTag("rightcol"))
        {
            gameObject.transform.parent.parent.GetComponent<moveHorseSample>().turnleft(1.2f);
        }
    }
}
