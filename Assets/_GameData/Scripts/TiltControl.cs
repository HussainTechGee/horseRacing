using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newAcc = Input.acceleration;
        if (newAcc.x == 0 && newAcc.y == 0)
        {
            Physics.gravity = new Vector2(0, -10);
        }
        else
        {
            Debug.Log("New Acceleration: " + newAcc);
            Physics.gravity = new Vector2(newAcc.x * 7.5f, newAcc.y * 7.5f);
        }
    }
}
