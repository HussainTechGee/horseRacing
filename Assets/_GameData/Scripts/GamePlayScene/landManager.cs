using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
public class landManager : MonoBehaviour
{
    public GameObject dustPartical;
    int num = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("foot"))
        {
            // GameObject temppartical = Instantiate(dustPartical, other.transform.position, dustPartical.transform.rotation);
            // Destroy(temppartical, .5f);
        }
        else if (other.gameObject.CompareTag("myfoot"))
        {
            // footstep();
            // GameObject temppartical = Instantiate(dustPartical, other.transform.position, dustPartical.transform.rotation);
            // Destroy(temppartical, .5f);
        }
    }

    void footstep()
    {
        if (moveHorseSample.instance.start)
        {
            SoundManager.instance.Play("step" + num);
            MMVibrationManager.Haptic(HapticTypes.LightImpact);
            num++;
            if (num > 2)
            {
                num = 1;
            }
        }

        //if (r != 3 && r != 1 && r != 5)
        //{
        //    MMVibrationManager.Haptic(HapticTypes.LightImpact);
        //}
    }
}
