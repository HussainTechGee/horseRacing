using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHorseSample : MonoBehaviour
{
    public Animator HorseController, RiderController;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveSample());
        // HorseController = gameObject.GetComponent<Animator>();
        // RiderController = gameObject.transform.GetChild(6).GetComponent<Animator>();
    }

    private IEnumerator moveSample()
    {
        yield return new WaitForSeconds(0);
        HorseController.SetTrigger("run");
        // yield return new WaitForSeconds(.5f);
        // StartCoroutine(moveSample());
    }
    public void OnTurnClick(string Direction)
    {
        HorseController.SetTrigger(Direction);
        RiderController.SetTrigger(Direction);
        HorseController.SetTrigger("run");
    }
    // public void OnLeftClick(string Direction)
    // {
    //     gameObject.GetComponent<Animator>().SetTrigger(Direction);
    //     gameObject.GetComponent<Animator>().SetTrigger("run");

    // }
}
