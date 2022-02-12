using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinAdaptor : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.color = SkinController.instance.CurrentSkin.color;
        }
    }

}
