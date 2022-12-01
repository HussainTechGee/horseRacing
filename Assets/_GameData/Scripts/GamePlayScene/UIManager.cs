using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;


public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public GameObject countingPanel, starting_gates;
    public Sprite[] counting;
    public GameObject[] skillButton;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        StartCoroutine(timePanel());
    }

    IEnumerator timePanel()
    {
        yield return new WaitForSeconds(12f);
        countingPanel.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[0];
        yield return new WaitForSeconds(1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[1];
        yield return new WaitForSeconds(.9f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[2];
        yield return new WaitForSeconds(.9f);
        countingPanel.SetActive(false);
        yield return new WaitForSeconds(3);
        starting_gates.SetActive(false);
    }
    public IEnumerator gotostarttimePanel()
    {

        yield return new WaitForSeconds(3f);
        countingPanel.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[0];
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[1];
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(.9f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[2];
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(.9f);
        countingPanel.SetActive(false);
        yield return new WaitForSeconds(3);
        starting_gates.SetActive(false);
    }

}
