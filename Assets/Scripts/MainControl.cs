using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    public RectTransform mainBg;
    public RectTransform customize;
    public GameObject sphere;
    public GameObject floor;

    private Vector2 start, end, delta;
    private bool isDown = false;
    private int mainWindow = 1;

    private void Start()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.size = new Vector2(Screen.width, Screen.height / 8);
        col.offset = new Vector2(0, -Screen.height / 2 + Screen.height / 16);
    }

    private void OnMouseDown()
    {
        start = Input.mousePosition;
        isDown = true;
        sphere.transform.SetParent(mainBg.gameObject.transform);
        floor.transform.SetParent(mainBg.gameObject.transform);
        //transform.SetParent(mainBg.gameObject.transform);
    }

    private void Update()
    {
        if (isDown)
        {
            end = Input.mousePosition;
            if (mainWindow == 1)
            {
                mainBg.offsetMax = customize.offsetMax = new Vector2(Mathf.Max(-1080, Mathf.Min(0, end.x - start.x)), 0);
                mainBg.offsetMin = customize.offsetMin = new Vector2(Mathf.Max(-1080, Mathf.Min(0, end.x - start.x)), 0);
            }
            else
            {
                mainBg.offsetMax = customize.offsetMax = new Vector2(Mathf.Max(-1080, Mathf.Min(0, -1080 + end.x - start.x)), 0);
                mainBg.offsetMin = customize.offsetMin = new Vector2(Mathf.Max(-1080, Mathf.Min(0, -1080 + end.x - start.x)), 0);
            }
        }
    }

    private void OnMouseUp()
    {
        end = Input.mousePosition;
        delta = end - start;
        if (mainWindow == 1)
        {
            if (delta.x < -540)
            {
                mainBg.offsetMax = customize.offsetMax = new Vector2(-1080, 0);
                mainBg.offsetMin = customize.offsetMin = new Vector2(-1080, 0);
                mainWindow = -1;
            }
            else
            {
                mainBg.offsetMin = customize.offsetMin = Vector2.zero;
                mainBg.offsetMax = customize.offsetMax = Vector2.zero;
                sphere.transform.SetParent(null);
                floor.transform.SetParent(null);
                //transform.SetParent(null);
            }

        }
        else if(mainWindow == -1)
        {
            if (delta.x < 540)
            {
                mainBg.offsetMax = customize.offsetMax = new Vector2(-1080, 0);
                mainBg.offsetMin = customize.offsetMin = new Vector2(-1080, 0);
            }
            else
            {
                mainBg.offsetMin = customize.offsetMin = Vector2.zero;
                mainBg.offsetMax = customize.offsetMax = Vector2.zero;
                sphere.transform.SetParent(null);
                floor.transform.SetParent(null);
                //transform.SetParent(null);
                mainWindow = 1;
            }
        }
        isDown = false;
    }
}
