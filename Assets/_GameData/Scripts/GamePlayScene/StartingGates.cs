using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StartingGates : MonoBehaviour
{
    Vector3 Oleftgate, Orightgate;
    Transform leftgate, rightgate;
    void Start()
    {
        leftgate = gameObject.transform.GetChild(0).GetChild(0);
        rightgate = gameObject.transform.GetChild(0).GetChild(1);
        Oleftgate = new Vector3(leftgate.rotation.eulerAngles.x, leftgate.rotation.eulerAngles.y - 90, leftgate.rotation.eulerAngles.z);
        Orightgate = new Vector3(rightgate.rotation.eulerAngles.x, rightgate.rotation.eulerAngles.y + 90, rightgate.rotation.eulerAngles.z);
    }
    public void openGates()
    {
        leftgate.DORotate(Oleftgate, .5f);
        rightgate.DORotate(Orightgate, .5f);
    }

}
