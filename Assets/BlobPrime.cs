using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobPrime : MonoBehaviour
{
    public int particleCount = 5;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < particleCount; i++)
        {
            Vector3 pos = gameObject.transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);


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

    // Update is called once per frame
    void Update()
    {
        
    }
}
