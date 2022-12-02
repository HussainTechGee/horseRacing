using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressManager : MonoBehaviour
{
    // public static ProgressManager instance;
    public int position;
    public Slider slider;
    public Transform pathPoints, Player, pathPoints2;
    private Transform endPoint, startPoint;
    Vector3 oldpos;
    private float maxdistance, dis1, dis2;
    public float distancetraveled;
    public GameObject playercanvas;
    public Image positonimage;
    public Sprite[] positions;

    void Start()
    {
        playercanvas = transform.GetChild(0).GetChild(4).GetChild(1).GetChild(2).gameObject;
        positonimage = playercanvas.transform.GetChild(0).GetComponent<Image>();
        //     if (instance == null)
        //     {
        //         instance = this;
        //     }
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
        if (moveHorseSample.instance.start)
        {
            if (distancetraveled < maxdistance)
            {
                float distance = (getDistance() / maxdistance);
                SetValue(distance);
            }
        }
        if (this.position != 0 && this.position <= 3)
        {
            {
                playercanvas.SetActive(true);
                positonimage.gameObject.SetActive(true);
                positonimage.sprite = positions[position - 1];
            }
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
