using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenlimit;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(speed, 0);
        screenlimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        //if offscreen
        if (transform.position.x < screenlimit.x*-2 || transform.position.y < screenlimit.y * -2)
        {
            Destroy(this.gameObject);
        }
    }
}
