using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;

   
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.AddForce (Vector2.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (inPlay == false)
        {
            transform.position = paddle.position;
        }


        
        if (Input.GetButtonDown("Jump") & inPlay == false)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);

        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            Transform newEsplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newEsplosion.gameObject, 2.5f);


            gm.UpdateScore(1);
            gm.UpdateNumberOfBricks();

            Destroy(other.gameObject);

        }
    }

   
} 

