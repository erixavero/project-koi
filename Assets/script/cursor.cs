using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    private float deltax, deltay;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && FindObjectOfType<GManager>().playing())
        {
            Touch t = Input.GetTouch(0);
            Vector2 tpos = Camera.main.ScreenToWorldPoint(t.position);

            switch(t.phase)
            {
                case TouchPhase.Began: //calculate movement
                    deltax = tpos.x - transform.position.x;
                    deltay = tpos.y - transform.position.y;
                    break;

                case TouchPhase.Moved: //move cursor
                    rb.MovePosition(new Vector2(tpos.x - deltax, tpos.y - deltay));
                    break;

                case TouchPhase.Ended: //stop cursor
                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }
}
