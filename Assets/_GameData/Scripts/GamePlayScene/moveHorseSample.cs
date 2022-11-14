using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class moveHorseSample : MonoBehaviour
{
    public static moveHorseSample instance;
    public Animator HorseController, RiderController;
    public Rigidbody rb;
    public GameObject horsewithrider;
    public float speed, turnspeed, turnduration, boostfactor;
    public bool freez, boost;
    bool start, sprint;

    void Start()
    {
        instance = this;
        StartCoroutine(StartGame());
        speed = speed / 4;

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
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
                    Debug.Log("left");
                    // HorseController.SetTrigger("turnleft");
                    if (!sprint)
                    {
                        RiderController.SetTrigger("turnleft");
                    }
                    else
                    {
                        RiderController.SetTrigger("turnlefts");
                    }
                    horsewithrider.transform.DORotate(new Vector3(0, horsewithrider.transform.rotation.eulerAngles.y - turnspeed, 0), turnduration);
                }
                else
                {
                    Debug.Log("right");
                    // HorseController.SetTrigger("turnright");

                    if (!sprint)
                    {
                        RiderController.SetTrigger("turnright");
                    }
                    else
                    {
                        RiderController.SetTrigger("turnrights");
                    }
                    horsewithrider.transform.DORotate(new Vector3(0, horsewithrider.transform.rotation.eulerAngles.y + turnspeed, 0), turnduration);
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
    public void Movement()
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
            HorseController.speed = 1.5f;
            RiderController.speed = 1.5f;
        }
        else if (freez)
        {
            horsewithrider.transform.Translate(0, 0, 0 + (speed * Time.deltaTime) * 0);
            HorseController.speed = 0f;
            RiderController.speed = 0f;
        }

    }

    public void homeBtnClick()
    {
        SceneManager.LoadScene(0);
    }

}
