using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobPrime : MonoBehaviour
{
    public int particleCount = 5;
    public GameObject particle;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 pos = gameObject.transform.position + new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0);


            if (Physics2D.OverlapCircle(pos, particle.transform.localScale.x / 2))
            {
                i--;
            }
            else
            {
                Instantiate(particle, pos, gameObject.transform.rotation);
            }
        }
    }

    void SpawnParticle()
    {
        Vector3 pos = gameObject.transform.position;
        Instantiate(particle, pos, gameObject.transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnParticle();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
