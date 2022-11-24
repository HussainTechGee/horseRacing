using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MissileSkillHolder1 : MonoBehaviour
{
    [HideInInspector] public bool startfire, move, Follow, followtarget;
    [HideInInspector] public PathCreator selectedPath;
    [HideInInspector] public GameObject attackTriggeredobj;
    [HideInInspector] public float speed = 150f;
    public static MissileSkillHolder1 instance;
    public GameObject[] attacktrigger;
    public GameObject rocketprefab;
    public Transform rocketStartPosition, rocketFollowPoint;
    public PathCreator[] rocketPaths;
    public Animator RiderController;

    float distancetravled, waitTime = 1;
    GameObject firedrocket;

    private void Start()
    {
        instance = this;
        RiderController = transform.GetChild(0).GetChild(4).GetComponent<Animator>();
    }
    private void Update()
    {

        if (startfire)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0.6)
            {
                if (firedrocket != null)
                {
                    Destroy(firedrocket);
                    Follow = false;
                }
                firedrocket = Instantiate(rocketprefab, rocketStartPosition.position, Quaternion.Euler(0, 0, 0));

                Vector3 targetpointonpath1 = rocketPaths[0].path.GetClosestPointOnPath(rocketStartPosition.position);
                Vector3 targetpointonpath2 = rocketPaths[1].path.GetClosestPointOnPath(rocketStartPosition.position);
                float tempdist1 = Vector3.Distance(rocketStartPosition.position, targetpointonpath1);
                float tempdist2 = Vector3.Distance(rocketStartPosition.position, targetpointonpath2);
                if (tempdist1 < tempdist2)
                {
                    selectedPath = rocketPaths[0];
                    rocketFollowPoint.position = rocketPaths[0].path.GetClosestPointOnPath(rocketFollowPoint.position);

                    rocketFollowPoint.position = new Vector3(rocketFollowPoint.position.x, 2.5f, rocketFollowPoint.position.z);
                    distancetravled = selectedPath.path.GetClosestDistanceAlongPath(rocketFollowPoint.position);
                }
                else
                {
                    selectedPath = rocketPaths[1];
                    rocketFollowPoint.position = rocketPaths[1].path.GetClosestPointOnPath(rocketFollowPoint.position);

                    rocketFollowPoint.position = new Vector3(rocketFollowPoint.position.x, 2.5f, rocketFollowPoint.position.z);
                    distancetravled = selectedPath.path.GetClosestDistanceAlongPath(rocketFollowPoint.position);
                }
                firedrocket.transform.GetChild(0).GetComponent<RocketScript>().initobject = this.gameObject;
                move = true;
                startfire = false;
                waitTime = 1;
            }
        }
        if (move)
        {
            if (firedrocket != null)
            {
                if (!followtarget)
                {
                    firedrocket.transform.position = Vector3.MoveTowards(firedrocket.transform.position, rocketFollowPoint.position, speed * Time.deltaTime);
                    firedrocket.transform.LookAt(rocketFollowPoint);
                    if (Vector3.Distance(firedrocket.transform.position, rocketFollowPoint.position) <= 0)
                    {
                        move = false;
                        Follow = true;
                    }
                }
            }
        }
        if (Follow)
        {
            if (firedrocket != null)
            {
                if (followtarget)
                {
                    for (int i = 0; i < attacktrigger.Length; i++)
                    {
                        if (attacktrigger[i].GetComponent<BoxCollider>().enabled)
                            attacktrigger[i].GetComponent<BoxCollider>().enabled = false;
                    }
                    selectedPath = null;
                    firedrocket.transform.position = Vector3.MoveTowards(firedrocket.transform.position,
                    new Vector3(attackTriggeredobj.transform.position.x, 2.5f, attackTriggeredobj.transform.position.z), speed * Time.deltaTime);
                    firedrocket.transform.LookAt(rocketFollowPoint);
                    // StartCoroutine(enableAttacktrigger());
                }
                else  //path
                {
                    distancetravled += speed * Time.deltaTime;
                    firedrocket.transform.position = new Vector3(selectedPath.path.GetPointAtDistance(distancetravled).x, 2.5f, selectedPath.path.GetPointAtDistance(distancetravled).z);
                    firedrocket.transform.rotation = selectedPath.path.GetRotationAtDistance(distancetravled);
                    // attacktrigger.GetComponent<BoxCollider>().enabled = true;
                }
            }
        }
    }
    public void onclickfire()
    {
        followtarget = false;
        RiderController.SetTrigger("firegun");
        for (int i = 0; i < attacktrigger.Length; i++)
        {
            if (!attacktrigger[i].GetComponent<BoxCollider>().enabled)
                attacktrigger[i].GetComponent<BoxCollider>().enabled = true;
        }

        startfire = true;
    }
    public IEnumerator enableAttacktrigger()
    {
        yield return new WaitForSeconds(4f);
        // attackTriggeredobj.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
