using UnityEngine;

public class Colliders : MonoBehaviour
{
    Rigidbody rb;
    RigidbodyConstraints originalConstraints;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        originalConstraints = rb.constraints;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("finish"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().win = true;
        }
        else if (other.gameObject.CompareTag("leftcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().turnright(1.2f);
            gameObject.transform.parent.GetComponent<moveHorseSample>().incollider = true;
        }
        else if (other.gameObject.CompareTag("rightcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().turnleft(1.2f);
            gameObject.transform.parent.GetComponent<moveHorseSample>().incollider = true;
        }
        else if (other.gameObject.CompareTag("land"))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("leftcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().incollider = true;
        }
        else if (other.gameObject.CompareTag("rightcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().incollider = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject.CompareTag("leftcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().incollider = false;
        }
        else if (other.gameObject.CompareTag("rightcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().incollider = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("leftcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().turnright(1.2f);
        }
        else if (other.gameObject.CompareTag("rightcol"))
        {
            gameObject.transform.parent.GetComponent<moveHorseSample>().turnleft(1.2f);
        }
    }
}
