using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAbosrber : MonoBehaviour
{

    [SerializeField] private float absorbsionStrength = 0.3f;
    private SpriteRenderer spriteRenderer;
    private Color baseColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Particle"))
        {
            SkinController.instance.Merge(collision.gameObject, spriteRenderer.color, absorbsionStrength);
        }
    }

}
