using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MissileSkillHolder : MonoBehaviour
{
    public GameObject rocketprefab;
    public AttackTriggerhandler attackTarget;
    public Transform rocketpleholder, missilefollowpoint;
    Vector3 targetpointonpath;
    public PathCreator[] paths;
    public PathCreator selectedpath;
    bool fired, startfire, move, settarget;
    public float speed, distancetravled;
    public Animator RiderController;
    GameObject firedrocket;
    float waitforTime = 1;
    private void Update()
    {

        if (startfire)
        {
            waitforTime -= Time.deltaTime;

            if (waitforTime <= 0.6)
            {
                firedrocket = Instantiate(rocketprefab, rocketpleholder.position, Quaternion.Euler(rocketprefab.transform.rotation.x, rocketprefab.transform.rotation.x - 180, rocketprefab.transform.rotation.z));
                StartCoroutine(destroywait());

                startfire = false;
                waitforTime = 1;
                Debug.LogError("fired");
                if (attackTarget.targetobj == null)
                {
                    int selectpath = Random.Range(0, paths.Length);
                    selectedpath = paths[selectpath];

                    distancetravled = selectedpath.path.GetClosestDistanceAlongPath(rocketpleholder.position);
                }
            }
        }
        if (fired)
        {
            if (firedrocket != null)
            {
                if (attackTarget.targetobj == null)
                {
                    distancetravled = selectedpath.path.GetClosestDistanceAlongPath(firedrocket.transform.position);
                    distancetravled += speed * Time.deltaTime;

                    Vector3 newpos = new Vector3(selectedpath.path.GetPointAtDistance(distancetravled).x, firedrocket.transform.position.y, selectedpath.path.GetPointAtDistance(distancetravled).z);
                    newpos.y = 2.5f;
                    firedrocket.transform.position = newpos;
                    Quaternion newRot = selectedpath.path.GetRotationAtDistance(distancetravled);
                    newRot.y -= 180;
                    firedrocket.transform.rotation = newRot;
                }
                else
                {
                    if (firedrocket != null)
                    {
                        if (settarget)
                        {
                            targetpointonpath = new Vector3(attackTarget.targetobj.transform.position.x, 2.5f, attackTarget.targetobj.transform.position.z);
                            settarget = false;
                        }
                        firedrocket.transform.position = Vector3.Lerp(firedrocket.transform.position, targetpointonpath, speed * Time.deltaTime);
                    }
                }
            }

        }
        else if (move && attackTarget.targetobj == null)
        {


            {
                targetpointonpath = selectedpath.path.GetClosestPointOnPath(missilefollowpoint.position);
                targetpointonpath = new Vector3(targetpointonpath.x, 2.5f, targetpointonpath.z);
                Debug.Log(targetpointonpath);

                if (firedrocket != null)
                { firedrocket.transform.position = Vector3.Lerp(firedrocket.transform.position, targetpointonpath, 2f * Time.deltaTime); }
            }

        }

    }



    public void onFire()
    {
        if (firedrocket != null)
        {
            Destroy(firedrocket);
        }
        startfire = true;
        RiderController.SetTrigger("firegun");

        // Debug.Log(paths[0].path.GetClosestPointOnPath(rocketpleholder.position));
        // Debug.Log();

    }

    private IEnumerator destroywait()
    {
        yield return new WaitForEndOfFrame();
        move = true;
        if (attackTarget.targetobj == null)
        {
            yield return new WaitForSeconds(.5f);
            fired = true;
            move = false;
        }
        else
        {
            settarget = true;
            fired = true;
            move = false;
        }

        yield return new WaitForSeconds(5);

        fired = false;
        if (firedrocket != null)
        {
            attackTarget.targetobj = null;
            Destroy(firedrocket);
        }

    }
}
