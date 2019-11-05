using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
	double fuel;
    Rigidbody2D rb;
    Vector2 force;
    public Text fuelText;
    
    // Start is called before the first frame update
    void Start()
    {
		fuel = 2.0;
        rb = GetComponent<Rigidbody2D>();
        fuelText.text = fuel.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;

        if (fuel > 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                force.x = 10;
                fuel -= Math.Round(1 * Time.deltaTime, 2);
                fuelText.text = fuel.ToString();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                force.y = 10;
                fuel -= Math.Round(1 * Time.deltaTime, 2);
                fuelText.text = fuel.ToString();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                force.x = -10;
                fuel -= Math.Round(1 * Time.deltaTime, 2);
                fuelText.text = fuel.ToString();
            }
        }else
        {
            fuelText.text = "0";
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -2, 2), rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            SceneManager.LoadScene("YouWin");
        } else if(collision.gameObject.tag == "Landscape")
        {
            SceneManager.LoadScene("YouFail");
        }
    }
}
