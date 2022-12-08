using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplingRope : MonoBehaviour
{
    [SerializeField] private GameObject rope;
    // [SerializeField] private GameObject ropeprefab;
    // [SerializeField] private Transform ropecirclestart;
    [SerializeField] private Transform target;
    [SerializeField] private float grapplespeed;
    [SerializeField] private LineRenderer _linerenderer;
    [SerializeField] private Transform linestartpos;
    [SerializeField] private bool grapple;
    [SerializeField] private Animator ridercontroller;
    [SerializeField] AttackTriggerandler AttackTrigger;

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
        if (AttackTrigger.targetobject != null)
        {
            target = AttackTrigger.targetobject.transform.GetChild(13);
        }
        if (target != null)
        {
            currentrope = ObjectPooler.instance.SpawnFromPool("rope", rope.transform.position, rope.transform.rotation);
            grapple = true;
            rope.SetActive(false);
            _linerenderer.enabled = true;
            ridercontroller.SetTrigger("trope");
            ridercontroller.SetInteger("ropedir", 1);
            StartCoroutine(endgrapple());
        }
    }

    IEnumerator endgrapple()
    {
        yield return new WaitForSeconds(.5f);
        grapple = false;
        currentrope.transform.parent = null;
        yield return new WaitForSeconds(.6f);
        currentrope.SetActive(false);
        target = null;
        AttackTrigger.targetobject = null;

    }
}
