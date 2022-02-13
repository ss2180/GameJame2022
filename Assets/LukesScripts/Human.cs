using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public LookAt facing;
    public GradedPath navAgent;
    public BasicAI ai;

    public List<Sprite> sprites = new List<Sprite>();

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ai.pointReached += point =>
        {
            facing.target = point;
        };

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
