using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BotPlyers : MonoBehaviour
{
    public static BotPlyers instance;
    public PathCreator pathCreator;
    public float speed, boostFactor;
    float distancetravled;
    public bool freez, boost;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!freez && !boost)
        {
            distancetravled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
        }
        else if (!freez && boost)
        {
            distancetravled += speed * boostFactor * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
        }
        else if (freez)
        {
            distancetravled += speed * 0 * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distancetravled);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distancetravled);
        }
    }
}
