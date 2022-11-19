using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BotPlyers : MonoBehaviour
{
    public static BotPlyers instance;
    private Animator botAnimator, RiderController;
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
    }
    // Update is called once per frame
    void Update()
    {
        if (!win)
        {
            if (start)
            {
                if (!freez && !boost)
                {
                    distancetravled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 1f;
                }
                else if (!freez && boost)
                {
                    distancetravled += speed * boostFactor * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 1.2f;
                }
                else if (freez && !shield)
                {
                    distancetravled += speed * 0 * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 0f;
                }
                else
                {
                    distancetravled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
                    botAnimator.speed = 1f;
                }
            }
        }
        else
        {
            botAnimator.SetTrigger("idle");
            RiderController.SetTrigger("idle");
        }
        if (shield)
        {
            shieldobj.SetActive(true);
        }
        else
        {
            shieldobj.SetActive(false);
        }
        if (freez)
        {
            icecubeObj.SetActive(true);
        }
        else
        {
            icecubeObj.SetActive(false);
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
}
