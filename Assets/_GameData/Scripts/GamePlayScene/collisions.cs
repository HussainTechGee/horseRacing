using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisions : MonoBehaviour
{
    public float startspeed, reducefactor;

    private void Start()
    {
        // startspeed = moveHorseSample.instance.speed;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "fence")
        {
            moveHorseSample.instance.speed = moveHorseSample.instance.speed / 2;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "fence")
        {
            // moveHorseSample.instance.speed = moveHorseSample.instance.speed - 10 * Time.deltaTime;
            reducefactor += Time.deltaTime;
            if (reducefactor > 2)
            {
                // gameObject.transform.parent.GetComponent<moveHorseSample>().enabled = false;
            }
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "fence")
        {
            // gameObject.transform.parent.GetComponent<moveHorseSample>().enabled = true;
            moveHorseSample.instance.speed = startspeed;
            reducefactor = 0;
        }
    }

    private void Update()
    {
        // reducefactor *= Time.time;
        // if (reducefactor > 20)
        // {
        //     reducefactor = 0;
        // }
    }
}
