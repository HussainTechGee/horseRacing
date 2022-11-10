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
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    private void Update()
    {
        if (Input.GetMouseButton(0) && !Input.GetMouseButtonUp(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                Debug.Log("left");
                // HorseController.SetTrigger("turnleft");
                RiderController.SetTrigger("turnleft");
                horsewithrider.transform.DORotate(new Vector3(0, horsewithrider.transform.rotation.eulerAngles.y - turnspeed, 0), turnduration);
            }
            else
            {
                Debug.Log("right");
                // HorseController.SetTrigger("turnright");
                RiderController.SetTrigger("turnright");
                horsewithrider.transform.DORotate(new Vector3(0, horsewithrider.transform.rotation.eulerAngles.y + turnspeed, 0), turnduration);
            }

        }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     if (Input.mousePosition.x < Screen.width / 2)
        //     {
        //         // Debug.Log("left");
        //         HorseController.SetTrigger("turnleft");
        //         RiderController.SetTrigger("turnleft");
        //         // horsewithrider.transform.DORotate(new Vector3(0, horsewithrider.transform.rotation.eulerAngles.y - turnspeed, 0), turnduration);
        //     }
        //     else
        //     {
        //         // Debug.Log("right");
        //         HorseController.SetTrigger("turnright");
        //         RiderController.SetTrigger("turnright");
        //         // horsewithrider.transform.DORotate(new Vector3(0, horsewithrider.transform.rotation.eulerAngles.y + turnspeed, 0), turnduration);
        //     }
        // }
        if (Input.GetMouseButtonUp(0))
        {
            HorseController.SetTrigger("run");
        }
        Movement();
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
    // public void onfreezButtonclick()
    // {
    //     if (freez)
    //     {
    //         freez = false;
    //     }
    //     else
    //     {
    //         freez = true;
    //     }
    // }
}
