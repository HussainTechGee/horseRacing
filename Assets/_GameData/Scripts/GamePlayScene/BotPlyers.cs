using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BotPlyers : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed;
    float distancetravled;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distancetravled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
        // transform.Translate(pathCreator.path.GetPointAtDistance(distancetravled).x, pathCreator.path.GetPointAtDistance(distancetravled).y, pathCreator.path.GetPointAtDistance(distancetravled).z);
    }
}
