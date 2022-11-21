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
    void Start()
    {
        Application.targetFrameRate = 60;
        _mcamera = Camera.main;
        cameratransform = gameObject.transform;
    }


    void Update()
    {

    }
    public void home0click(bool isScreen0)
    {

        StartCoroutine(home0to1(isScreen0));

    }

    private IEnumerator home0to1(bool isScreen0)
    {
        if (isScreen0)
        {
            cameratransform.DORotate(new Vector3(16.659f, 79.335f, -0.191f), .5f);
            yield return new WaitForSeconds(.2f);
            gameObject.transform.DOMove(new Vector3(459.254f, 1.204f, -5.028f), .5f);
            yield return new WaitForSeconds(.35f);
            home1.SetActive(true);
        }
        else
        {
            gameObject.transform.DOMove(new Vector3(450.47f, .58f, 0.25f), .5f);
            yield return new WaitForSeconds(.35f);
            gameObject.transform.DORotate(new Vector3(-12.193f, 0, 0), .5f);
            yield return new WaitForSeconds(.2f);
            home0.SetActive(true);
        }
    }
    public void onPlayButtonClick()
    {
        SceneManager.LoadScene("SampleScene");

    }
}
