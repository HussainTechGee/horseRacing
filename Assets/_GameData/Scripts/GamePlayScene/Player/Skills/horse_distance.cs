using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class horse_distance : MonoBehaviour
{
    //all horses 1st horse is that on which script is added
    public GameObject[] horses;

    // rocket path
    public PathCreator path;
    public bool startfire, moverocket;
    [SerializeField] GameObject target;
    public Transform rocketStartPosition;
    public GameObject rocketPrefab;
    GameObject firedRocket;
    float dist1, dist2, tempdist, _time = 1;
    Animator RiderController;
    private void Start()
    {
        RiderController = horses[0].transform.GetChild(4).GetComponent<Animator>();
    }
    private void FixedUpdate()
    {

        if (moverocket)
        {
            if (firedRocket != null)
            {
                if (target != null)
                {
                    firedRocket.transform.LookAt(target.transform);
                    firedRocket.transform.GetChild(0).position = Vector3.MoveTowards(firedRocket.transform.GetChild(0).position,
                     new Vector3(target.transform.position.x, 2.5f, target.transform.position.z), 150 * Time.deltaTime);
                    // firedRocket.transform.position = firedRocket.transform.GetChild(0).position;
                    // firedRocket.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10, ForceMode.VelocityChange);
                    // firedRocket.transform.GetChild(0).transform.position = firedRocket.transform.position;
                }
                else
                {
                    firedRocket.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1.5f, ForceMode.Impulse);
                }
            }
        }
    }
    public void onClickFire()
    {
        moverocket = false;
        target = null;
        gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        RiderController.SetTrigger("firegun");
        Debug.LogError("Fired by :" + gameObject.name);
        StartCoroutine(rockerfire());
        // startfire = true;
    }
    IEnumerator rockerfire()
    {
        yield return new WaitForSeconds(0.5f);
        dist1 = path.path.GetClosestDistanceAlongPath(horses[0].transform.position);
        tempdist = dist1;
        for (int i = 1; i < horses.Length; i++)
        {
            dist2 = path.path.GetClosestDistanceAlongPath(horses[i].transform.position);
            if (dist2 > dist1)
            {
                if (dist2 > tempdist)
                {
                    target = horses[i];
                    tempdist = dist2;
                }
            }
        }
        if (firedRocket != null)
        {
            firedRocket.SetActive(false);
        }
        // firedRocket = Instantiate(rocketPrefab, rocketStartPosition.position, rocketStartPosition.transform.rotation);
        firedRocket = ObjectPooler.instance.SpawnFromPool("rocket", rocketStartPosition.position, rocketStartPosition.rotation);
        mfiredRocket = firedRocket.GetComponent<Rigidbody>();
        StartCoroutine(ResetRigidbodyAndDisable(mfiredRocket, firedRocket));
        moverocket = true;
    }
    Rigidbody mfiredRocket;
    IEnumerator ResetRigidbodyAndDisable(Rigidbody rb, GameObject rocketobj)
    {
        yield return new WaitForSeconds(15f);
        if (mfiredRocket != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            rb = rocketobj.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;

        rocketobj.SetActive(false);
    }
}
