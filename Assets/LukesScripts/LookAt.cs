using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Vector3 target;
    public float rotationSpeed;

    private Quaternion lookRotation;
    private Vector3 direction;

    void Update()
    {
        if (target == null)
            return;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, target - transform.position);
    }
}
