using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressManager : MonoBehaviour
{
    public Slider slider;
    public Transform endPoint, startPoint, Player;
    float maxdistance;


    void Start()
    {
        maxdistance = Vector3.Distance(endPoint.position, startPoint.position);
        slider.value = 1 - (getDistance() / maxdistance);
    }

    void Update()
    {
        if (Player.position.z <= endPoint.position.z)
        {
            float distance = 1 - (getDistance() / maxdistance);
            SetValue(distance);
        }

    }
    private float getDistance()
    {
        return Vector3.Distance(Player.position, endPoint.position);
    }
    private void SetValue(float p)
    {
        slider.value = p;
    }
}
