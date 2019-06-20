using UnityEngine;

public class playerhit : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource smack;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    //if fish is hit
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "obst")
        {
            smack.Play();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1;

            FindObjectOfType<GManager>().gameover();
        }
    }
}
