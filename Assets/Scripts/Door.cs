using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float speed = 5f;

    public GameObject Left;
    public GameObject Right;

    private bool open = true;

    private void Update()
    {
        Left.transform.localPosition = new Vector2(Left.transform.localPosition.x + speed * Time.deltaTime, Left.transform.localPosition.y);
        Right.transform.localPosition = new Vector2(Right.transform.localPosition.x - speed * Time.deltaTime, Right.transform.localPosition.y);
        if (open)
        {
            if (Left.transform.localPosition.x >= -1f)
            {
                open = false;
                speed /= 4f;
                swap(ref Left, ref Right);
            }
        }
        else
        {
            if (Right.transform.localPosition.x <= -2f)
            {
                speed *= 4f;
                open = true;
                swap(ref Left, ref Right);
            }
        }
    }
    private void swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}
