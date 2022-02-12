using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float force = 5f;
    public Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            Move();
    }

    void Move()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, vertical, 0f);

        body.AddForce(direction * force);
    }
}
