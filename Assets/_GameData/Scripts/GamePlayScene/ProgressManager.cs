using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;


public class ProgressManager : MonoBehaviour
{
    // public static ProgressManager instance;
    public int position;
    public Slider slider;
    public Transform Player;
    private Transform endPoint, startPoint;
    // Vector3 oldpos;
    private float maxdistance, dis1, dis2;
    public float distancetraveled;
    public GameObject playercanvas;
    public Image positionimage;
    public Sprite[] positions;

    [SerializeField] private PathCreator path;

    [SerializeField] private float duration = 0.5f;
    // [SerializeField] private bool isfromPath;
    void Start()
    {
        playercanvas = transform.GetChild(0).GetChild(4).GetChild(1).GetChild(2).gameObject;
        positionimage = playercanvas.transform.GetChild(0).GetComponent<Image>();


        // oldpos = Player.transform.position;

        // slider.value = (getDistance() / maxdistance);
        // StartCoroutine(checkValue());

    }

    void Update()
    {
        // if (moveHorseSample.instance.start)
        // {
        //     if (distancetraveled < maxdistance)
        //     {
        //         float distance = (getDistance() / maxdistance);
        //         SetValue(distance);
        //     }
        // }
        if (GetComponent<ProgressManager>().position != 0 && GetComponent<ProgressManager>().position <= 3)
        {
            // GetComponent<ProgressManager>().playercanvas.SetActive(true);
            GetComponent<ProgressManager>().positionimage.gameObject.SetActive(true);
            GetComponent<ProgressManager>().positionimage.sprite = positions[position - 1];
        }
    }
    private float getDistance()
    {
        // if (!isfromPath)
        // {
        //     // Vector3 distanceVector = Player.transform.position - oldpos;
        //     // float distanceThisFrame = distanceVector.magnitude;
        //     // distancetraveled += distanceThisFrame;
        //     // oldpos = Player.transform.position;
        //     // return distancetraveled;
        //     return 0;
        // }
        // else
        {
            distancetraveled = path.path.GetClosestDistanceAlongPath(Player.position);

            return distancetraveled;
        }
    }

    // private IEnumerator checkValue()
    // {
    //     yield return new WaitForSeconds(duration);
    //     if (moveHorseSample.instance.start)
    //     {
    //         if (distancetraveled < maxdistance)
    //         {
    //             float distance = (getDistance() / maxdistance);
    //             SetValue(distance);
    //         }
    //     }
    //     StartCoroutine(checkValue());
    // }
    private void SetValue(float p)
    {
        slider.value = p;
        Debug.Log(p);
    }

}
