using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public Camera cam;
    public GameObject DeathWindow;
    public Text ScoreText;

    public float horizontalForce = 100f;
    public float verticalForce = 300f;


    private Rigidbody2D rb;
    private bool toRight = false;
    private int score = -1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DeathWindow.SetActive(false);
    }

    private void Update()
    {
        cam.transform.position = new Vector2(cam.transform.position.x, Mathf.Max(cam.transform.position.y, transform.position.y));
        
        if(cam.transform.position.y - transform.position.y > 20)
        {
            Death();
        }
        if(score * 10 < cam.transform.position.y - 30)
        {
            score++;
            ScoreText.text = score.ToString();
        }

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            if (toRight)
            {
                rb.AddForce(new Vector2(horizontalForce, verticalForce));
            }
            else
            {
                rb.AddForce(new Vector2(-horizontalForce, verticalForce));
            }
            toRight = !toRight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Red")
        {
            Death();
        }
    }

    private void Death()
    {
        rb.simulated = false;
        DeathWindow.SetActive(true);
    }
}
