using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostingSkilHolder : MonoBehaviour
{
    public static boostingSkilHolder instance;
    public float boosttimer = 1;
    bool boost;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (boost)
        {
            boosttimer -= Time.deltaTime;
        }

        if (boosttimer <= -1)
        {
            gameObject.GetComponent<moveHorseSample>().boost = false;
            boost = false;
            boosttimer = 1;
        }
    }

    public void onBoostBtnClick()
    {
        gameObject.GetComponent<moveHorseSample>().boost = true;
        boost = true;
    }

}
