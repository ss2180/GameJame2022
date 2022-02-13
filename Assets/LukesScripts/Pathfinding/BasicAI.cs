using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    public GradedPath navAgent;
    public float speed = 5f;
    public Vector3 nextPoint = Vector3.zero;
    private int currentPoint = -1;
    public bool reachedDestination = false;

    public bool useRandomPosition = true;

    private void Start()
    {
        StartCoroutine(WaitForNavigationGrid());
    }

    IEnumerator WaitForNavigationGrid()
    {
        yield return new WaitUntil(() => navAgent.grid.ready);

        Execute();
    }

    void Execute()
    {
        //TODO fix bug with out of bounds and convert into Vector3 GetRandomPosition()
        Vector3 destination = navAgent.dest;
        if (useRandomPosition)
        {
            destination = new Vector3(Random.Range(0, navAgent.grid.cells.x), 0, Random.Range(0, navAgent.grid.cells.y));
            while (!navAgent.IsValidAt((int)destination.x, (int)destination.y, 0))
            {
                destination = new Vector3(Random.Range(0, navAgent.grid.cells.x), 0, Random.Range(0, navAgent.grid.cells.y));
            }
        }

        navAgent.src = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), 0);
        navAgent.dest = new Vector3(Mathf.RoundToInt(destination.x), Mathf.RoundToInt(destination.y), 0);
        MoveToDestination();
    }

    private void Update()
    {
        // We have a path
        if (currentPoint != -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);
        }
    }

    public void MoveToDestination()
    {
        navAgent.CalculatePath();
        if(!navAgent.PathWasSuccessful())
        {
            //Debug.LogError("Failed to find a successful route to the destination");
            Execute();
            return;
        }
        StartCoroutine(MoveAgent(0));
    }

    IEnumerator MoveAgent(int openIndex)
    {
        reachedDestination = navAgent.open.Count <= 0 || openIndex >= navAgent.open.Count;
        if (reachedDestination)
        {
            currentPoint = -1;
            nextPoint = Vector3.zero;
            Execute();
            yield break;
        }

        currentPoint = openIndex;
        GridCell next = navAgent.open[openIndex];
        nextPoint = next.position;
        yield return new WaitUntil(() => Vector3.Distance(transform.position, nextPoint) < 1f);
        StartCoroutine(MoveAgent(openIndex + 1));
    }
}
