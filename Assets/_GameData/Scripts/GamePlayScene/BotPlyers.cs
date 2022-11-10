using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BotPlyers : MonoBehaviour
{
    public static botScript instance;
    public PathCreator pathCreator;
    public float speed;
    float distancetravled;
    public bool freez;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!freez)
        {
            distancetravled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
        }
    }
}
