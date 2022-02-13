using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public GameObject humanPrefab;

    public List<Transform> spawnPoints = new List<Transform>();

    public int humanLimit = 25;
    private List<GameObject> humans = new List<GameObject>();
    public bool CanSpawn { 
        get
        {
            return humans.Count < humanLimit;
        }
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, UnityEngine.Random.Range(3, 5));
        int spawnCount = UnityEngine.Random.Range(1, humanLimit);
        for (int i = 0; i < spawnCount; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (!CanSpawn)
            return;

        Debug.Log("Spawned human");
        var position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)].position;
        var human = Instantiate(humanPrefab, position, Quaternion.identity);
        humans.Add(human);
    }

    public void Despawn(GameObject obj)
    {
        Debug.Log("Despawned human!");
        humans.Remove(obj);
        Destroy(obj);
    }

}
