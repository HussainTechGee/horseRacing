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
    public bool start;
    bool sprint;
    [HideInInspector] public float startspeed;

    void Start()
    {
        instance = this;
        StartCoroutine(StartGame());
        startspeed = speed;
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
        HorseController.SetTrigger("sprint");
        RiderController.SetTrigger("sprint");
        sprint = true;
    }
    private void Update()
    {

        if (start)
        {
            if (!win)
            {
                if (Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0))
                {
                    if (sprint)
                    {
                        if (Input.mousePosition.x < Screen.width / 2)
                        {
                            if (!incollider && !freez)
                            {
                                turnleft(1);
                            }
                        }
                        else
                        {
                            if (!incollider && !freez)
                            {
                                turnright(1);
                            }
                        }
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    if (!sprint)
                        HorseController.SetTrigger("run");
                    else
                        HorseController.SetTrigger("sprint");
                }
            }

            Movement();

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                StopAllCoroutines();
                StartCoroutine(UIManager.instance.gotostarttimePanel());
                StartCoroutine(cutSceneScript.instance.gotostart());
                StartCoroutine(gotostart());
            }
        }
    }
    IEnumerator gotostart()
    {
        yield return new WaitForSeconds(5);
        HorseController.SetTrigger("run");
        RiderController.SetTrigger("run");
        speed = speed * 4;
        //sprint
        start = true;
        yield return new WaitForSeconds(2);
        HorseController.SetTrigger("sprint");
        RiderController.SetTrigger("sprint");
        sprint = true;
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
            if (!freez && !boost && !shield)
            {
                horsewithrider.transform.Translate(0, 0, 0 + speed * Time.deltaTime);
                HorseController.speed = 1.2f;
                RiderController.speed = 1.2f;
                shieldobject.SetActive(false);
                IcecubeObj.SetActive(false);
                boostObj.SetActive(false);
            }
            else if (boost && !freez)
            {
                horsewithrider.transform.Translate(0, 0, 0 + speed * boostfactor * Time.deltaTime);
                HorseController.speed = 1.6f;
                RiderController.speed = 1.6f;
                boostObj.SetActive(true);
            }
            else if (freez && !shield && !boost)
            {
                horsewithrider.transform.Translate(0, 0, 0 + (speed * Time.deltaTime) * 0);
                HorseController.speed = 0f;
                RiderController.speed = 0f;
                IcecubeObj.SetActive(true);
            }

            else if (boost && shield)
            {
                horsewithrider.transform.Translate(0, 0, 0 + speed * boostfactor * Time.deltaTime);
                HorseController.speed = 1.6f;
                RiderController.speed = 1.6f;
                boostObj.SetActive(true);
                shieldobject.SetActive(true);
                IcecubeObj.SetActive(false);
            }
            else if (shield)
            {
                horsewithrider.transform.Translate(0, 0, 0 + speed * Time.deltaTime);
                HorseController.speed = 1f;
                RiderController.speed = 1f;
                shieldobject.SetActive(true);
                IcecubeObj.SetActive(false);
            }
            else if (freez && boost)
            {
                horsewithrider.transform.Translate(0, 0, 0 + (speed * Time.deltaTime) * 0);
                HorseController.speed = 0f;
                RiderController.speed = 0f;
                IcecubeObj.SetActive(true);
                boostObj.SetActive(false);
            }
        }
        else
        {
            horsewithrider.transform.Translate(0, 0, 0 + speed * Time.deltaTime);
            HorseController.speed = 1f;
            RiderController.speed = 1f;
            shieldobject.SetActive(false);
            IcecubeObj.SetActive(false);
            boostObj.SetActive(false);
        }


    }

    public void homeBtnClick()
    {
        SceneManager.LoadScene(0);
    }
    bool alreadychecked;

    public IEnumerator playerWin()
    {
        var tempSpeed = speed;
        if (!alreadychecked)
        {

            StartCoroutine(cutSceneScript.instance.onWin());

            alreadychecked = true;
        }
        yield return new WaitForEndOfFrame();
        if (speed <= tempSpeed / 2)
        {
            HorseController.SetTrigger("walk");
            RiderController.SetTrigger("walk");
        }
        if (speed > 0)
        {
            speed -= 0.05f;
        }
        else
        {
            HorseController.SetTrigger("idle");
            RiderController.SetTrigger("idle");
        }
        StartCoroutine(playerWin());
    }
}
