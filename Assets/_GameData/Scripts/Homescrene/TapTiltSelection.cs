using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTiltSelection : MonoBehaviour
{


    public void onclickcontrol(int istilt)
    {
        PlayerPrefs.SetInt("tilt", istilt);
    }
}
