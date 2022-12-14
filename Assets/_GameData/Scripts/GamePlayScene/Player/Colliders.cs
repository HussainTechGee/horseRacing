using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Colliders : MonoBehaviour
{
    Rigidbody rb;
    RigidbodyConstraints originalConstraints;
    public GameObject explosion;
    public Animator skillbuttoncontroller;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        originalConstraints = rb.constraints;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("leftcol"))
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
        else if (other.gameObject.CompareTag("freez"))
        {
            UIManager.instance.skillButton[0].SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject, 1f));
            skillbuttoncontroller.SetTrigger("freez");
        }
        else if (other.gameObject.CompareTag("boost"))
        {
            UIManager.instance.skillButton[1].SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject, 1f));
            skillbuttoncontroller.SetTrigger("boost");
        }
        else if (other.gameObject.CompareTag("shield"))
        {
            UIManager.instance.skillButton[2].SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject, 1f));
            skillbuttoncontroller.SetTrigger("shield");
        }
        else if (other.gameObject.CompareTag("rocketpick"))
        {
            UIManager.instance.skillButton[3].SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(activeSkillPick(other.gameObject, 1f));
            skillbuttoncontroller.SetTrigger("fire");
        }
        else if (other.gameObject.CompareTag("fence"))
        {
            Debug.Log("inHurdle");
            // gameObject.transform.parent.GetComponent<Animator>().SetTrigger("death");
            // if (!transform.parent.GetComponent<moveHorseSample>().missilehit)
            {
                // transform.parent.GetComponent<moveHorseSample>().missilehit = true;
                // explosion.SetActive(true);
                // explosion.transform.GetChild(0).gameObject.SetActive(true);
                // explosion.transform.GetChild(1).gameObject.SetActive(true);
                // explosion.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                // explosion.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
                missilehit.instance.targetobj = gameObject.transform.parent.gameObject;
                missilehit.instance.explosion = explosion;
                missilehit.instance.rockethit = true;
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(activatecollider(other.gameObject, .5f));
            }
        }

    }
    IEnumerator activatecollider(GameObject current, float duration)
    {
        yield return new WaitForSeconds(duration);
        current.GetComponent<BoxCollider>().enabled = true;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish"))
        {

            gameObject.transform.parent.GetComponent<moveHorseSample>().win = true;
            StartCoroutine(moveHorseSample.instance.playerWin());

        }
        else if (other.gameObject.CompareTag("rocket"))
        {
            // Debug.Log(gameObject.transform.parent.name);
            // Debug.Log("rockethit");
            if (!transform.parent.GetComponent<moveHorseSample>().missilehit && !transform.parent.GetComponent<moveHorseSample>().shield)
            {
                transform.parent.GetComponent<moveHorseSample>().missilehit = true;
                explosion.SetActive(true);
                explosion.transform.GetChild(0).gameObject.SetActive(true);
                explosion.transform.GetChild(1).gameObject.SetActive(true);
                explosion.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                explosion.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
                missilehit.instance.targetobj = gameObject.transform.parent.gameObject;
                missilehit.instance.explosion = explosion;
                missilehit.instance.rockethit = true;
            }
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }

    }

    private IEnumerator activeSkillPick(GameObject current, float duration)
    {
        yield return new WaitForSeconds(duration);
        current.gameObject.SetActive(true);
    }
}
