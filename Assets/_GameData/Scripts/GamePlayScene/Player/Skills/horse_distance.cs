using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class horse_distance : MonoBehaviour
{
    public GameObject[] horses;
    public PathCreator path;
    public bool startfire, moverocket;
    GameObject target;
    public Transform rocketStartPosition;
    public GameObject rocketPrefab;
    GameObject firedRocket;
    float dist1, dist2, tempdist;
    private void Update()
    {
        if (startfire)
        {
            dist1 = path.path.GetClosestDistanceAlongPath(horses[0].transform.position);
            for (int i = 0; i < horses.Length - 1; i++)
            {
                dist2 = path.path.GetClosestDistanceAlongPath(horses[i + 1].transform.position);
                if (dist2 > dist1)
                {
                    dist1 = dist2;
                    target = horses[i + 1];
                }
            }
            // if (firedRocket != null)
            // {
            //     Destroy(firedRocket);
            // }


            // firedRocket = Instantiate(rocketPrefab, rocketStartPosition.position, rocketStartPosition.transform.rotation);
            firedRocket = ObjectPooler.instance.SpawnFromPool("rocket", rocketStartPosition.position, rocketStartPosition.rotation);
            mfiredRocket = firedRocket.GetComponent<Rigidbody>();
            StartCoroutine(ResetRigidbodyAndDisable());
            moverocket = true;
            startfire = false;
        }

        if (moverocket)
        {
            if (firedRocket != null)
            {
                if (target != null)
                {
                    firedRocket.transform.LookAt(target.transform);
                    firedRocket.transform.position = Vector3.MoveTowards(firedRocket.transform.position,
                     new Vector3(target.transform.position.x, 2.5f, target.transform.position.z), 150 * Time.deltaTime);
                }
                else
                {
                    firedRocket.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10, ForceMode.VelocityChange);
                }
            }
        }
    }
    public void onClickFire()
    {
        target = null;
        startfire = true;
    }
    Rigidbody mfiredRocket;
    IEnumerator ResetRigidbodyAndDisable()
    {
        if (mfiredRocket != null)
        {
            mfiredRocket.GetComponent<Rigidbody>().velocity = Vector3.zero;
            mfiredRocket.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        else
        {
            mfiredRocket = firedRocket.GetComponent<Rigidbody>();
            mfiredRocket.velocity = Vector3.zero;
            mfiredRocket.angularVelocity = Vector3.zero;
        }

        yield return new WaitForSeconds(5f);
        firedRocket.SetActive(false);
    }
}
