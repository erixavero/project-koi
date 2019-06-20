using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall
    : MonoBehaviour
{
    private float xspeed = 5f;
    private Rigidbody2D rb;
    private Vector2 screenlimit;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenlimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if(transform.position.x < screenlimit.x / 2)
        {
            rb.velocity = new Vector2(xspeed, -3 * transform.position.y/(screenlimit.y*3/2));
            rb.AddTorque(10);
        }
        else
        {
            rb.velocity = new Vector2(-xspeed, -3 * transform.position.y / (screenlimit.y * 3 / 2));
            rb.AddTorque(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if offscreen
        if (transform.position.y < screenlimit.y*-2)
        {
            Destroy(this.gameObject);
        }
        //Debug.Log(rb.velocity);
    }
}
