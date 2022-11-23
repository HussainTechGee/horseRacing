using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BotPlyers : MonoBehaviour
{
    public static BotPlyers instance;
    [HideInInspector] public Animator botAnimator, RiderController;
    public PathCreator pathCreator;
    public float speed, boostFactor;
    float distancetravled;
    public bool freez, boost, win, shield;
    public GameObject shieldobj, icecubeObj, boostObj;
    bool start = true;
    // Start is called before the first frame update
    void Start()
    {
        botAnimator = transform.GetChild(0).GetComponent<Animator>();
        RiderController = transform.GetChild(0).GetChild(4).GetComponent<Animator>();
        speed = speed / 4;
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(.01f);
        start = false;
        yield return new WaitForSeconds(14.99f);
        botAnimator.SetTrigger("run");
        RiderController.SetTrigger("run");
        //sprint
        speed = speed * 4;
        start = true;
        yield return new WaitForSeconds(2);
        botAnimator.SetTrigger("sprint");
        RiderController.SetTrigger("sprint");
    }
    // Update is called once per frame
    void Update()
    {
        if (!win)
        {
            if (start)
            {
                if (!freez && !boost && !shield)
                {
                    distancetravled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 1.2f;
                    shieldobj.SetActive(false);
                    boostObj.SetActive(false);
                    icecubeObj.SetActive(false);
                }
                else if (!freez && boost)
                {
                    distancetravled += speed * boostFactor * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 1.6f;
                    boostObj.SetActive(true);
                }
                else if (shield && boost)
                {
                    distancetravled += speed * boostFactor * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 1.2f;
                    boostObj.SetActive(true);
                    shieldobj.SetActive(true);
                    icecubeObj.SetActive(false);
                }
                else if (freez && !shield)
                {
                    distancetravled += speed * 0 * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 0f;
                    icecubeObj.SetActive(true);
                }
                else if (shield)
                {
                    distancetravled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 1.2f;
                    shieldobj.SetActive(true);
                    icecubeObj.SetActive(false);
                }
            }
        }
        else
        {
            distancetravled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
            botAnimator.speed = 1f;
            shieldobj.SetActive(false);
            boostObj.SetActive(false);
            icecubeObj.SetActive(false);
        }

    }

    bool alreadychecked;

    public IEnumerator botWin()
    {
        if (!alreadychecked)
        {
            speed /= 2;
            botAnimator.SetTrigger("walk");
            RiderController.SetTrigger("walk");
            alreadychecked = true;
        }
        yield return new WaitForEndOfFrame();
        if (speed > 0)
        {
            speed -= 0.0004f;
            StartCoroutine(botWin());
        }
        else
        {
            botAnimator.SetTrigger("idle");
            RiderController.SetTrigger("idle");
        }
    }
}
