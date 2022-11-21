using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutSceneScript : MonoBehaviour
{
    public static cutSceneScript instance;
    [SerializeField] GameObject[] Scenes;
    [SerializeField] GameObject winpanel;
    [SerializeField] GameObject playercamera, blackpanel;
    private void Start()
    {
        if (instance == null)
        { instance = this; }
        StartCoroutine(AnimateScene());
    }
    public IEnumerator onWin()
    {
        yield return new WaitForSeconds(1f);
        playercamera.SetActive(false);
        blackpanel.SetActive(true);
        yield return new WaitForSeconds(.2f);
        winpanel.SetActive(true);
        yield return new WaitForSeconds(.5f);
        winpanel.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
