using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class MoveRocket : MonoBehaviour
{

    public GameObject target;
    public PathCreator selectedpath;
    public float distancetravled, speed;
    public bool start, followpath, followtarget;
    public Vector3 targetpointonpath;




    private void Update()
    {
        if (followpath)
        {
            distancetravled = selectedpath.path.GetClosestDistanceAlongPath(transform.position);
            distancetravled += speed * Time.deltaTime;
            Vector3 newpos = new Vector3(selectedpath.path.GetPointAtDistance(distancetravled).x, transform.position.y, selectedpath.path.GetPointAtDistance(distancetravled).z);
            newpos.y = 2.5f;
            transform.position = newpos;
            Quaternion newRot = selectedpath.path.GetRotationAtDistance(distancetravled);
            newRot.y -= 180;
            transform.rotation = newRot;
        }
        else if (followtarget)
        {

            transform.position = Vector3.Lerp(transform.position, targetpointonpath, 2f * Time.deltaTime);
        }
    }
}




