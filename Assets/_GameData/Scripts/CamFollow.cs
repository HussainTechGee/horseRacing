using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    private void Start()
    {
        
    }
    void Update()
    {
        transform.position = Target.position + offset;
    }
}
