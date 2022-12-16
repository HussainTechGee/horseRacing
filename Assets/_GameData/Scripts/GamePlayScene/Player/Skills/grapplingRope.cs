using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class grapplingRope : MonoBehaviour
{
    [SerializeField] private GameObject rope;
    [SerializeField] private GameObject[] horses;
    [SerializeField] private PathCreator path;
    [SerializeField] private Transform target;
    [SerializeField] private float grapplespeed;
    [SerializeField] private LineRenderer _linerenderer;
    [SerializeField] private Transform linestartpos;
    [SerializeField] private bool grapple;
    [SerializeField] private Animator ridercontroller;
    [SerializeField] private AttackTriggerandler AttackTrigger;
    [SerializeField] private float minDist = 50, maxDist = 500;
    float dist1, dist2, tempdist;

    GameObject currentrope;
    private void Start()

    {

        // ropecirclestart = rope.transform;
        _linerenderer.enabled = false;
    }
    private void Update()
    {

        if (grapple)
        {

            currentrope.transform.position = Vector3.Lerp(rope.transform.position, target.position, grapplespeed * Time.deltaTime);
            // rope.transform.position = Vector3.Lerp(rope.transform.position, target.transform.position, grapplespeed * Time.deltaTime);
        }
        else
        {
            // rope.transform.position = ropecirclestart.position;
            _linerenderer.enabled = false;
        }
    }
    private void LateUpdate()
    {
        if (_linerenderer.enabled)
        {
            _linerenderer.SetPosition(0, currentrope.transform.GetChild(0).position);
            _linerenderer.SetPosition(1, linestartpos.position);

        }
    }
    public void startgrapple()
    {
        bool firsttime = false;
        float currentDist;
        dist1 = path.path.GetClosestDistanceAlongPath(gameObject.transform.GetChild(0).position);

        for (int i = 0; i < horses.Length; i++)
        {
            currentDist = Vector3.Distance(horses[i].transform.GetChild(0).position, gameObject.transform.GetChild(0).position);

            dist2 = path.path.GetClosestDistanceAlongPath(horses[i].transform.GetChild(0).position);
            if (dist2 > dist1)
            {
                if (!firsttime && currentDist > minDist && currentDist < maxDist)
                {
                    Debug.Log(currentDist);
                    tempdist = dist2;
                    target = horses[i].transform.GetChild(0).GetChild(12);
                    firsttime = true;
                }
                else if (tempdist > dist2 && currentDist > minDist && currentDist < maxDist)
                {
                    Debug.Log(currentDist);
                    tempdist = dist2;
                    target = horses[i].transform.GetChild(0).GetChild(12);
                }


                // if (dist2 < tempdist)
                // {

                //     // tempdist = dist2;
                // }
            }
        }
        if (target != null)
        {
            currentrope = ObjectPooler.instance.SpawnFromPool("rope", rope.transform.position, rope.transform.rotation);
            grapple = true;
            rope.SetActive(false);
            _linerenderer.enabled = true;
            ridercontroller.SetTrigger("trope");
            ridercontroller.SetInteger("ropedir", 1);
            Debug.LogError("ropehitted");
            StartCoroutine(endgrapple());
        }
    }

    IEnumerator endgrapple()
    {
        yield return new WaitForSeconds(.5f);
        grapple = false;
        currentrope.transform.parent = null;
        yield return new WaitForSeconds(1f);
        target = null;
        yield return new WaitForSeconds(1);
        currentrope.GetComponent<BoxCollider>().enabled = true;
        currentrope.SetActive(false);

    }
}
