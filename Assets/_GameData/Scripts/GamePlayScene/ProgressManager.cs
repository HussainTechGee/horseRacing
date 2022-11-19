using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressManager : MonoBehaviour
{
    public Slider slider;
    public Transform pathPoints, Player, pathPoints2;
    private Transform endPoint, startPoint;
    Vector3 oldpos;
    private float maxdistance, distancetraveled, dis1, dis2;


    void Start()
    {
        for (int i = 0; i < pathPoints.childCount; i++)
        {
            if (i < pathPoints.childCount - 1)
            {
                endPoint = pathPoints.GetChild(i + 1);
                startPoint = pathPoints.GetChild(i);
                dis1 += Vector3.Distance(endPoint.position, startPoint.position);
            }
            if (i < pathPoints2.childCount - 1)
            {
                endPoint = pathPoints.GetChild(i + 1);
                startPoint = pathPoints.GetChild(i);
                dis2 += Vector3.Distance(endPoint.position, startPoint.position);
            }
        }
        maxdistance = (dis1 + dis2) / 2;
        oldpos = Player.transform.position;
        slider.value = (getDistance() / maxdistance);
    }
    // [SerializeField] float distance;
    void Update()
    {
        if (distancetraveled < maxdistance)
        {
            float distance = (getDistance() / maxdistance);
            SetValue(distance);
        }
    }
    private float getDistance()
    {
        Vector3 distanceVector = Player.transform.position - oldpos;
        float distanceThisFrame = distanceVector.magnitude;
        distancetraveled += distanceThisFrame;
        oldpos = Player.transform.position;
        return distancetraveled;
    }
    private void SetValue(float p)
    {
        slider.value = p;
    }
}
