using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipedetection : MonoBehaviour
{

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public static bool left, right;
    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                    left = true;
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                    right = true;
                }
            }
        }
    }
    Vector2 mousefirstPressPos;
    Vector2 mousesecondPressPos;
    Vector2 mousecurrentSwipe;

    public void mouseSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            mousefirstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            mousesecondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            mousecurrentSwipe = new Vector2(mousesecondPressPos.x - mousefirstPressPos.x, mousesecondPressPos.y - mousefirstPressPos.y);

            //normalize the 2d vector
            mousecurrentSwipe.Normalize();

            //swipe upwards
            if (mousecurrentSwipe.y > 0 && mousecurrentSwipe.x > -0.5f && mousecurrentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
            }
            //swipe down
            if (mousecurrentSwipe.y < 0 && mousecurrentSwipe.x > -0.5f && mousecurrentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
            }
            //swipe left
            if (mousecurrentSwipe.x < 0 && mousecurrentSwipe.y > -0.5f && mousecurrentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
                left = true;
            }
            //swipe right
            if (mousecurrentSwipe.x > 0 && mousecurrentSwipe.y > -0.5f && mousecurrentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
                right = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        left = false;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseSwipe();
    }
}
