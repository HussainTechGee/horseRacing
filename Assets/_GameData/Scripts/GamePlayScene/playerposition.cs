using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;


public class playerposition : MonoBehaviour
{
    [SerializeField] private Slider[] sliders;
    [SerializeField] private Transform[] players;
    [SerializeField] private PathCreator path;
    // [SerializeField] private float duration = 0.5f;
    [SerializeField] Transform pathPoints, pathPoints2;
    private Transform endPoint, startPoint;
    private float maxdistance, dis1, dis2;
    [SerializeField] private float[] distancetraveled;
    [SerializeField] private GameObject[] progresPositions;
    [SerializeField] private float[] tempsortedarray;
    [SerializeField] private int[] templist;
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
            sliders[i].value = (getDistance(i) / maxdistance);
            tempsortedarray[i] = distancetraveled[i];
        }
        // Invoke("sort", 1f);

        // StartCoroutine(checkValue());

    }
    int temp = 0;
    float tempval = 0;
    float getDistance(int i)
    {
        distancetraveled[i] = path.path.GetClosestDistanceAlongPath(players[i].position);

        return distancetraveled[i];
    }
    [SerializeField] bool trysort;
    private void Update()
    {
        if (trysort)
        {
            for (int k = 0; k < tempsortedarray.Length; k++)
            {
                tempsortedarray[k] = distancetraveled[k];
            }
            sort();
        }

    }
    private void LateUpdate()
    {
        checkValue();
    }
    int index = 0;
    // private IEnumerator checkValue()
    void checkValue()
    {

        if (index >= players.Length)
        {
            index = 0;
        }
        // yield return new WaitForSeconds(0.0000001f);
        if (moveHorseSample.instance.start)
        {
            if (distancetraveled[index] < maxdistance)
            {

                float distance = (getDistance(index) / maxdistance);
                // tempsortedarray[index] = distancetraveled[index];


                SetValue(distance, index);
            }
            index++;
        }

        // StartCoroutine(checkValue());
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
            templist[j] = maxind;
            tempval = tempsortedarray[maxind];
            tempsortedarray[maxind] = tempsortedarray[j];
            tempsortedarray[j] = tempval;

        }
        for (int i = 0; i < templist.Length; i++)
        {
            progresPositions[i].transform.GetChild(1).GetComponent<Text>().text = players[templist[i]].parent.gameObject.name;

        }
        trysort = false;
    }
}
