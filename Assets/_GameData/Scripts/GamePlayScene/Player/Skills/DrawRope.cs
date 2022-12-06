using UnityEngine;
using System.Collections;
public class DrawRope : MonoBehaviour
{
    public Transform start, end;
    public Material ropematerial;
    public float duration = 5f;
    GameObject myLine;
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(_drawrope());
        }
        // if (myLine != null)
        // {
        //     myLine.transform.position = start.position;
        // }
    }
    IEnumerator _drawrope()
    {
        float starttime = Time.time;
        myLine = new GameObject();
        myLine.transform.position = start.position;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = ropematerial;
        // lr.SetColors(Color.white, Color.white);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, start.position);
        lr.SetPosition(1, end.position);
        yield return null;
    }
}