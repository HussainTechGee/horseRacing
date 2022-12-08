using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    IEnumerator reverseobj(GameObject bot)
    {
        bot.GetComponent<BotPlyers>().speed *= -1;
        yield return new WaitForSeconds(1f);
        bot.GetComponent<BotPlyers>().speed *= -1;
        bot = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            Debug.Log(other.gameObject.name);
            gameObject.transform.parent = other.gameObject.transform.GetChild(13);
            StartCoroutine(reverseobj(other.transform.parent.gameObject));

        }
    }
}
