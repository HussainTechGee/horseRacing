using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landManager : MonoBehaviour
{
    public GameObject dustPartical;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("foot"))
        {
            Invoke("footstep", .2f);
            // GameObject temppartical = Instantiate(dustPartical, other.transform.position, other.transform.rotation);

            // Destroy(temppartical, .5f);
        }
    }

    void footstep()
    {
        SoundManager.instance.Play("step");
    }
}
