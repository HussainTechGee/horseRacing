using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutSceneScript : MonoBehaviour
{
    public static cutSceneScript instance;
    [SerializeField] GameObject[] Scenes;
    [SerializeField] public GameObject winpanel;
    [SerializeField] GameObject playercamera, blackpanel;
    private void Start()
    {
        if (instance == null)
        { instance = this; }
        StartCoroutine(AnimateScene());
    }
    // public IEnumerator onWin()
    // {
    //     yield return new WaitForSeconds(1f);
    //     playercamera.SetActive(false);
    //     blackpanel.SetActive(true);
    //     yield return new WaitForSeconds(.2f);
    //     winpanel.SetActive(true);
    //     yield return new WaitForSeconds(.4f);
    //     winpanel.transform.GetChild(1).gameObject.SetActive(true);
    //     yield return new WaitForSeconds(6f);
    //     // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
    public IEnumerator onWin()
    {
        playercamera.SetActive(false);
        // yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(.5f);
        blackpanel.SetActive(true);
        winpanel.SetActive(true);
        winpanel.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //  blackpanel.SetActive(true);
        Time.timeScale = 0.1f;
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

    public IEnumerator gotostart()
    {
        StopAllCoroutines();
        if (Scenes[0].activeInHierarchy)
        {
            Scenes[0].SetActive(false);
            blackpanel.SetActive(false);
        }
        else if (Scenes[1].activeInHierarchy)
        {
            Scenes[1].SetActive(false);
            blackpanel.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        blackpanel.SetActive(true);
        Scenes[2].SetActive(true);
        yield return new WaitForSeconds(.2f);
        Scenes[2].SetActive(false);
        yield return new WaitForSeconds(.2f);
        playercamera.SetActive(true);
        yield return new WaitForSeconds(1f);
        blackpanel.SetActive(false);
    }
}
