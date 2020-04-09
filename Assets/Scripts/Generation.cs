using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public Transform Sphere;
    public GameObject[] barriers;

    private int last = -1;

    private void Update()
    {
        if((int)(Sphere.position.y / 10f) > last)
        {
            last = (int)(Sphere.position.y / 10f);
            Instantiate(barriers[Random.Range(0, 2)], new Vector3(Random.Range(-11, 12), (last + 3) * 10f, 9), Quaternion.Euler(0f, 0f, Random.Range(0, 13) * 15f));
        }
    }
}
