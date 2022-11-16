using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public GameObject countingPanel;


    private void Start()
    {
        StartCoroutine(timePanel());
    }

    private IEnumerator timePanel()
    {
        yield return new WaitForSeconds(12f);
        countingPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        countingPanel.transform.GetChild(0).GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1f);
        countingPanel.transform.GetChild(0).GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1f);
        countingPanel.SetActive(false);
    }

}
