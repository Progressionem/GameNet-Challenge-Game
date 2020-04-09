using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    public float speed = 9f;

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, speed * 10 * Time.deltaTime));
    }
}
