using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    IEnumerator reverseobj(GameObject bot)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        bot.transform.GetChild(0).GetComponent<Animator>().SetTrigger("ropehit");
        bot.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("ropehit");
        bot.GetComponent<BotPlyers>().speed *= -1;
        yield return new WaitForSeconds(.8f);
        bot.transform.GetChild(0).GetComponent<Animator>().SetTrigger("sprint");
        bot.transform.GetChild(0).GetChild(4).GetComponent<Animator>().SetTrigger("sprint");
        yield return new WaitForSeconds(1f);
        bot.GetComponent<BotPlyers>().speed = bot.GetComponent<BotPlyers>().startSpeed;
        bot = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            Debug.Log(other.gameObject.name);
            gameObject.transform.parent = other.gameObject.transform.GetChild(13);
            this.StopAllCoroutines();
            this.StartCoroutine(reverseobj(other.transform.parent.gameObject));
        }
    }
}
