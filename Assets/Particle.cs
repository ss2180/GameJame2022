using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
