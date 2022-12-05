using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    private Camera _mcamera;
    [SerializeField] GameObject home0, home1, home2;
    Transform cameratransform;
    public GameObject virtualcameras;
    void Start()
    {
        Application.targetFrameRate = 60;
        _mcamera = Camera.main;
        cameratransform = gameObject.transform;
    }
    public void home0click(bool isScreen0)
    {

        StartCoroutine(home0to1(isScreen0));

    }

    private IEnumerator home0to1(bool isScreen0)
    {
        if (isScreen0)
        {
            virtualcameras.transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            home1.SetActive(true);
        }
        else
        {
            virtualcameras.transform.GetChild(1).gameObject.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            home0.SetActive(true);
        }
    }
    public void onPlayButtonClick()
    {
        SceneManager.LoadScene("SampleScene");

    }
}
