using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FreezingSkillHolder : MonoBehaviour
{
    public static FreezingSkillHolder instance;
    public BotPlyers[] players;
    bool freez;
    public float freeztimer = 2f;
    public GameObject freezUI, icepartical;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void onfreezClick()
    {
        gameObject.GetComponent<FreezingSkillHolder>().StopAllCoroutines();
        if (!freez)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (!players[i].shield)
                { players[i].freez = true; }
            }
            freez = true;
            gameObject.GetComponent<FreezingSkillHolder>().StartCoroutine(unfreezAll());
        }
        GetComponent<moveHorseSample>().RiderController.SetTrigger("freez");
        icepartical.SetActive(true);
    }

    IEnumerator unfreezAll()
    {
        yield return new WaitForSeconds(freeztimer);
        if (freez)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].freez = false;
            }
            freez = false;
        }
    }
    public IEnumerator freezUIA()
    {
        yield return null;
        // freezUI.SetActive(true);
        freezUI.GetComponent<Image>().DOFade(.2f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(1f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(0.2f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(1f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(0.2f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(1f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(.2f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(1f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(0.2f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(1f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(0.2f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        freezUI.GetComponent<Image>().DOFade(1f, 0.3f);
        yield return new WaitForSeconds(0.4f);
        // freezUI.SetActive(false);

    }
}
