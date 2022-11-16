using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutSceneScript : MonoBehaviour
{
    [SerializeField] GameObject[] Scenes;
    [SerializeField] GameObject playercamera, blackpanel;
    private void Start()
    {
        StartCoroutine(AnimateScene());
    }

    private IEnumerator AnimateScene()
    {
        yield return new WaitForSeconds(.1f);
        Scenes[0].transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        Scenes[0].SetActive(false);
        //Animation scene1


        yield return new WaitForSeconds(.1f);
        blackpanel.SetActive(true);
        Scenes[1].SetActive(true);
        yield return new WaitForSeconds(.06f);
        Scenes[1].transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        Scenes[1].SetActive(false);
        blackpanel.SetActive(false);
        //Animation scene2

        yield return new WaitForSeconds(.1f);

        blackpanel.SetActive(true);
        Scenes[2].SetActive(true);
        yield return new WaitForSeconds(.2f);
        playercamera.SetActive(true);
        yield return new WaitForSeconds(1f);
        blackpanel.SetActive(false);

    }
}
