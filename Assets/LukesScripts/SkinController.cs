using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    [SerializeField] private int currentSkinIndex = 2;
    public int skinIndex {
        get {
            return currentSkinIndex;
        }
        set {
            var val = value;
            if(val <= 0)
            {
                val = 0;
            } 
            else if(val >= skins.Length)
            {
                val = skins.Length - 1;
            }
            currentSkinIndex = val;
            Debug.Log($"Set skin to {val}");
        }
    }
    public Skin CurrentSkin { 
        get {
            return skins[skinIndex];
        }
    }

    public Skin[] skins = {
        new Skin(new Color(89, 44, 27)),
        new Skin(new Color(127, 192, 229)),
        new Skin(new Color(17, 113, 48)),
        new Skin(new Color(195, 127, 229)),
        new Skin(new Color(201, 192, 185)),
        new Skin(Color.green)
    };


    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Start()
    {
        ChangeSkin(0);
    }

    private void OnValidate()
    {
        ChangeSkin(skinIndex);
    }

    public void ChangeSkin(int index)
    {
        skinIndex = index;
        spriteRenderer.color = CurrentSkin.color;
    }

}

[System.Serializable]
public class Skin {

    public Color color;

    public Skin(Color color)
    {
        this.color = color;
    }
}