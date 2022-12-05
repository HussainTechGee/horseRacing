using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.NiceVibrations;


public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public GameObject countingPanel, starting_gates, finishLine, taportilt, skipbutton;
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
        skipbutton.SetActive(false);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[0];
        SoundManager.instance.Play("count");
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[1];
        SoundManager.instance.Play("count");
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(.9f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[2];
        SoundManager.instance.Play("count");
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < starting_gates.transform.childCount; i++)
        {
            starting_gates.transform.GetChild(i).GetComponent<StartingGates>().openGates();
        }
        yield return new WaitForSeconds(.4f);
        countingPanel.SetActive(false);

        if (moveHorseSample.instance.isTilt)
        {
            taportilt.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            taportilt.transform.GetChild(1).gameObject.SetActive(true);
        }
        SoundManager.instance.Play("fire");
        MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        yield return new WaitForSeconds(3);
        starting_gates.SetActive(false);
        finishLine.SetActive(true);
        yield return new WaitForSeconds(1);
        taportilt.SetActive(false);
    }
    public IEnumerator gotostarttimePanel()
    {
        yield return new WaitForSeconds(5f);
        countingPanel.SetActive(true);
        skipbutton.SetActive(false);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[0];
        SoundManager.instance.Play("count");
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[1];
        SoundManager.instance.Play("count");
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(.9f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
        countingPanel.transform.GetChild(0).gameObject.SetActive(true);
        countingPanel.transform.GetChild(0).GetComponent<Image>().sprite = counting[2];
        SoundManager.instance.Play("count");
        MMVibrationManager.Haptic(HapticTypes.SoftImpact);
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < starting_gates.transform.childCount; i++)
        {
            starting_gates.transform.GetChild(i).GetComponent<StartingGates>().openGates();
        }
        yield return new WaitForSeconds(.4f);
        countingPanel.SetActive(false);

        if (moveHorseSample.instance.isTilt)
        {
            taportilt.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            taportilt.transform.GetChild(1).gameObject.SetActive(true);
        }
        SoundManager.instance.Play("fire");
        MMVibrationManager.Haptic(HapticTypes.MediumImpact);
        yield return new WaitForSeconds(3);
        starting_gates.SetActive(false);
        finishLine.SetActive(true);
        yield return new WaitForSeconds(1);
        taportilt.SetActive(false);
    }


}
