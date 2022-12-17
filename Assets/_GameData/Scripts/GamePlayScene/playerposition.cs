using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;


public class playerposition : MonoBehaviour
{
    public static playerposition instance;
    [SerializeField] private Slider[] sliders;
    [SerializeField] private GameObject[] players;
    [SerializeField] private PathCreator path;
    [SerializeField] Transform pathPoints, pathPoints2;
    [SerializeField] private GameObject[] progresPositions;
    private Transform endPoint, startPoint;
    private float[] distancetraveled = new float[6];
    private float[] tempsortedarray = new float[6];
    private GameObject[] tempplayersList = new GameObject[6];
    private float maxdistance, dis1, dis2;
    bool trysort;
    float tempval = 0;
    int index = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
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
        for (int i = 0; i < sliders.Length; i++)
        {
            tempplayersList[i] = players[i];
            sliders[i].value = (getDistance(i) / maxdistance);
            tempsortedarray[i] = distancetraveled[i];
        }
        StartCoroutine(enablesort());

    }

    float getDistance(int i)
    {
        distancetraveled[i] = path.path.GetClosestDistanceAlongPath(players[i].transform.position);

        return distancetraveled[i];
    }

    private void Update()
    {
        if (trysort)
        {
            for (int k = 0; k < tempsortedarray.Length; k++)
            {
                tempsortedarray[k] = distancetraveled[k];
                tempplayersList[k] = players[k];
            }
            Invoke("sort", 0.05f);
        }

    }
    private void LateUpdate()
    {
        checkValue();
    }

    void checkValue()
    {
        if (index >= players.Length)
        {
            index = 0;
        }
        if (moveHorseSample.instance.start)
        {
            if (distancetraveled[index] < maxdistance)
            {
                float distance = (getDistance(index) / maxdistance);
                SetValue(distance, index);
            }
            index++;
        }
    }
    private void SetValue(float p, int i)
    {
        sliders[i].value = p;
    }
    void sort()
    {
        for (int j = 0; j < tempsortedarray.Length; j++)
        {
            int maxind = j;
            for (int k = j; k < tempsortedarray.Length; k++)
            {
                if (tempsortedarray[k] > tempsortedarray[maxind])
                {
                    maxind = k;
                }
            }
            GameObject tempgameObject = tempplayersList[maxind];
            tempplayersList[maxind] = tempplayersList[j];
            tempplayersList[j] = tempgameObject;

            tempval = tempsortedarray[maxind];
            tempsortedarray[maxind] = tempsortedarray[j];
            tempsortedarray[j] = tempval;

        }
        for (int j = 0; j < tempplayersList.Length; j++)
        {
            progresPositions[j].transform.GetChild(1).GetChild(0).GetComponent<Text>().text = tempplayersList[j].transform.parent.gameObject.name;
        }
        trysort = false;
    }
    private IEnumerator enablesort()
    {
        yield return new WaitForSeconds(0.1f);
        trysort = true;
        StartCoroutine(enablesort());
    }
}
