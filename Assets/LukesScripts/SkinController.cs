using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{

    public static SkinController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    [SerializeField] private int currentSkinIndex = 2;
    public int skinIndex
    {
        get
        {
            return currentSkinIndex;
        }
        set
        {
            var val = value;
            if (val <= 0)
            {
                val = 0;
            }
            else if (val >= skins.Length)
            {
                val = skins.Length - 1;
            }
            currentSkinIndex = val;
            Debug.Log($"Set skin to {val}");
        }
    }
    public Skin CurrentSkin
    {
        get
        {
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


    private void Start()
    {
        ChangeSkin(0);
    }

    private void OnValidate()
    {
        if (BlobPrime.instance == null)
            return;

        for(int i = 0; i < BlobPrime.instance.particles.Count; i++)
        {
            var col = BlobPrime.instance.particles[i].GetComponent<SpriteRenderer>().color;
            ChangeSkinSingular(skinIndex, BlobPrime.instance.particles[i]);
            Merge(BlobPrime.instance.particles[i], col, 0.4f);
        }
        //ChangeSkin(skinIndex);
    }

    public void ChangeSkin(int index)
    {
        if (BlobPrime.instance == null)
            return;

        skinIndex = index;
        for (int i = 0; i < BlobPrime.instance.particles.Count; i++)
        {
            ChangeSkinSingular(index, BlobPrime.instance.particles[i]);
        }
    }

    public void ChangeSkinSingular(int index, GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().color = CurrentSkin.color;
    }

    public Color Merge(GameObject hit, Color col, float blendStrength = 0.3f)
    {
        var renderer = hit.GetComponent<SpriteRenderer>();
        var newColor = Color.Lerp(renderer.color, col, blendStrength);
        renderer.color = newColor;
        return newColor;
    }


}

[System.Serializable]
public class Skin
{

    public Color color;

    public Skin(Color color)
    {
        this.color = color;
    }
}