using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingTest : MonoBehaviour
{
    public GradedPath navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent.CalculatePath();
    }

}
