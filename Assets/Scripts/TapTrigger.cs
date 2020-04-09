using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapTrigger : MonoBehaviour
{
    public GameObject sphere;
    //public GameObject firstCell;
    public GameObject[] DisappearObjects;
    public Text score;
    //public GameObject cell;

    private bool _isPlaying = false;

    public bool isPlaying
    {
        get { return _isPlaying; }
    }

    private void Start()
    {
        //cell = firstCell;
        GetComponent<BoxCollider2D>().size = new Vector2(Screen.width, Screen.height * 3 / 4);
    }

    private void OnMouseUp()
    {
        if (!isPlaying)
        {
            _isPlaying = true;
            StartGame();
        }
    }
    public void StartGame()
    {
        sphere.GetComponent<Rigidbody2D>().simulated = true;
        for (int i = 0; i < DisappearObjects.Length; i++)
        {
            DisappearObjects[i].SetActive(false);
        }
        score.text = "0";
    }
}
