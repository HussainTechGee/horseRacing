using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public float turn, offTimer, startTimer;
    public Transform startPos;
    public string side;
    Animator animator;
    Rigidbody rb;

    private void Start()
    {
        startPos = this.gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(moveit());
    }
    private void Update()
    {
        // rb.velocity = Vector3.forward * speed;
    }
    private IEnumerator moveit()
    {
        yield return new WaitForSeconds(startTimer);
        animator.SetTrigger("run");
        yield return new WaitForSeconds(turn);
        animator.SetTrigger(side);
        yield return new WaitForSeconds(.4f);
        animator.SetTrigger("run");
        yield return new WaitForSeconds(offTimer);
        gameObject.SetActive(false);
        // yield return new WaitForSeconds(startTimer / 2);
        // gameObject.SetActive(true);
        // gameObject.transform.position = startPos.transform.position;
        // gameObject.transform.rotation = startPos.transform.rotation;
        // StartCoroutine(moveit());

    }

}
