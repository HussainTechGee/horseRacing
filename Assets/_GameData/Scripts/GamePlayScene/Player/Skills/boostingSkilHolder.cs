using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostingSkilHolder : MonoBehaviour
{
    public static boostingSkilHolder instance;
    public float boosttimer = 2;
    bool boost;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void onBoostBtnClick()
    {
        this.StopAllCoroutines();
        gameObject.GetComponent<moveHorseSample>().boost = true;
        boost = true;
        StartCoroutine(stopBooster());
    }
    IEnumerator stopBooster()
    {
        yield return new WaitForSeconds(boosttimer);
        if (boost)
        {
            gameObject.GetComponent<moveHorseSample>().boost = false;
            boost = false;
        }
    }
}
