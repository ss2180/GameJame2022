using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAbosrber : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Color baseColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor = spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SkinController.instance.Merge(spriteRenderer.color);
        }
    }

}
