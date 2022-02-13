using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameObject player;
    private Rigidbody rb;

    public float constant = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.green;

        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force = player.transform.position - gameObject.transform.position;

        rb.AddForce(force.normalized * constant);
    }
}
