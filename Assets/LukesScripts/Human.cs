using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject parent;
    public LookAt facing;
    public GradedPath navAgent;
    public BasicAI ai;

    public new BoxCollider collider;

    public List<Sprite> sprites = new List<Sprite>();

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ai.pointReached += point =>
        {
            facing.target = point;
        };

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];

    }

    void Kill()
    {
        Debug.Log("Killing");
        for (int i = 0; i < UnityEngine.Random.Range(3, 10); i++)
        {
            BlobPrime.instance.SpawnParticle();
        }
        Spawner.instance.Despawn(parent);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Particle"))
        {
            if(Vector3.Distance(transform.position, SkinController.instance.gameObject.transform.position) <= 5f)
            {
                Kill();
            }
        }
    }
}
