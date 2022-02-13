using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSetSkin : MonoBehaviour
{
    public int skin = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Skin"))
            this.skin = PlayerPrefs.GetInt("Skin");
    }

    public void UpdateSkin(int id)
    {
        this.skin = id;
        PlayerPrefs.SetInt("Skin", skin);
    }
}
