using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathManager : MonoBehaviour
{
    public List<PathCreator> paths;
    public List<PathCreator> randompaths = new List<PathCreator>();

    int randomindex;

    public GameObject[] bots;
    void Start()
    {
        int length = paths.Count;
        while (randompaths.Count != length)
        {
            randomindex = Random.Range(0, paths.Count);
            randompaths.Add(paths[randomindex]);
            paths.RemoveAt(randomindex);
        }
        for (int i = 0; i < bots.Length; i++)
        {
            randomindex = Random.Range(0, randompaths.Count);
            bots[i].GetComponent<BotPlyers>().pathCreator = randompaths[randomindex];
            randompaths.RemoveAt(randomindex);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
