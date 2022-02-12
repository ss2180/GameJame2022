using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float force = 5f;
    public float maxVelocity = 10f;
    public float maxAngularVelocity = 60f;
    public Rigidbody2D body;

    private void FixedUpdate()
    {
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
        body.angularVelocity = Mathf.Clamp(body.angularVelocity, -maxAngularVelocity, maxAngularVelocity);

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
