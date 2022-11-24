using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RocketScript : MonoBehaviour
{
    bool followtarget;
    Transform target;
    public GameObject initobject;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("attack"))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            target = other.gameObject.transform;
            Debug.LogError("target: " + other.gameObject.transform.parent.name);
            followtarget = true;
            initobject.GetComponent<MissileSkillHolder1>().followtarget = true;
            initobject.GetComponent<MissileSkillHolder1>().Follow = true;
            initobject.GetComponent<MissileSkillHolder1>().move = false;
            initobject.GetComponent<MissileSkillHolder1>().attackTriggeredobj = other.gameObject;
        }
    }
}