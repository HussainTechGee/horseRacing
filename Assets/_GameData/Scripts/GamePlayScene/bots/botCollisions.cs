using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            gameObject.transform.parent.GetComponent<BotPlyers>().win = true;
        }
    }
}
