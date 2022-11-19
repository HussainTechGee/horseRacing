using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class moveHorseSample : MonoBehaviour
{
    public static moveHorseSample instance;
    public Animator HorseController, RiderController;
    public GameObject horsewithrider, shieldobject, IcecubeObj, boostObj;
    public float speed, turnspeed, turnduration, boostfactor;
    public bool freez, boost, win, incollider, shield;
    bool start, sprint;

    void Start()
    {
        instance = this;
        StartCoroutine(StartGame());
        speed = speed / 4;

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(15);
        HorseController.SetTrigger("run");
        RiderController.SetTrigger("run");
        speed = speed * 4;
        //sprint
        start = true;
        yield return new WaitForSeconds(2);
        sprint = true;
    }
    private void Update()
    {
        if (start)
        {
            if (Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0))
            {
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    if (!incollider && !freez)
                    { turnleft(1); }
                }
                else
                {
                    if (!incollider && !freez)
                    { turnright(1); }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (!sprint)
                    HorseController.SetTrigger("run");
                else
                    HorseController.SetTrigger("sprint");
            }

            Movement();

        }
    }
    public void turn(string direction)
    {
        HorseController.SetTrigger(direction);
        RiderController.SetTrigger(direction);
    }
    public void turnleft(float factor)
    {
        if (!sprint)
        {
            RiderController.SetTrigger("turnleft");
        }
        else
        {
            RiderController.SetTrigger("turnlefts");
        }
        horsewithrider.transform.DORotate(new Vector3(0, horsewithrider.transform.rotation.eulerAngles.y - turnspeed * factor, 0), turnduration / factor);
    }
    public void turnright(float factor)
    {
        if (!sprint)
        {
            RiderController.SetTrigger("turnright");
        }
        else
        {
            RiderController.SetTrigger("turnrights");
        }
        horsewithrider.transform.DORotate(new Vector3(0, horsewithrider.transform.rotation.eulerAngles.y + turnspeed * factor, 0), turnduration / factor);
    }
    public void Movement()
    {
        if (!win)
        {
            if (!freez && !boost)
            {
                horsewithrider.transform.Translate(0, 0, 0 + speed * Time.deltaTime);
                HorseController.speed = 1f;
                RiderController.speed = 1f;
            }
            else if (boost && !freez)
            {
                horsewithrider.transform.Translate(0, 0, 0 + speed * boostfactor * Time.deltaTime);
                HorseController.speed = 1.3f;
                RiderController.speed = 1.3f;
            }
            else if (freez && !shield)
            {
                horsewithrider.transform.Translate(0, 0, 0 + (speed * Time.deltaTime) * 0);
                HorseController.speed = 0f;
                RiderController.speed = 0f;
            }
            else
            {
                horsewithrider.transform.Translate(0, 0, 0 + speed * Time.deltaTime);
                HorseController.speed = 1f;
                RiderController.speed = 1f;
            }
        }
        else
        {
            HorseController.SetTrigger("idle");
            RiderController.SetTrigger("idle");
            StartCoroutine(cutSceneScript.instance.onWin());
        }
        if (shield)
        {
            shieldobject.SetActive(true);
        }
        else
        {
            shieldobject.SetActive(false);
        }
        if (freez)
        {
            IcecubeObj.SetActive(true);
        }
        else
        {
            IcecubeObj.SetActive(false);
        }
        if (boost)
        {
            boostObj.SetActive(true);
        }
        else
        {
            boostObj.SetActive(false);
        }

    }

    public void homeBtnClick()
    {
        SceneManager.LoadScene(0);
    }

}
