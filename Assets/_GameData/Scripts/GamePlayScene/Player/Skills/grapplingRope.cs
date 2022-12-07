using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplingRope : MonoBehaviour
{
    [SerializeField] private GameObject rope;
    [SerializeField] private Transform start;
    [SerializeField] private Transform target;
    [SerializeField] private float grapplespeed;
    [SerializeField] private bool grapple;

    private void Update()
    {
        if (grapple)
        {
            rope.transform.position = Vector3.Lerp(rope.transform.position, target.transform.position, grapplespeed * Time.deltaTime);
        }
        else
        {
            rope.transform.position = start.position;
        }
    }
}
