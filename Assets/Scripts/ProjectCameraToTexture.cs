using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectCameraToTexture : MonoBehaviour
{

    public bool realtime = true;
    public float updateRate = 0.5f;
    [Header("Camera to project")]
    public Camera projection;
    [Header("Image Resolution")]
    public int width = 256;
    public int height = 256;
    [Header("Colour depth")]
    public int depth = 16;
    [Header("Base lit material")]
    public Material unlit;

    private RenderTexture screen;

    void Start()
    {
        SetupProjection();
    }

    public void SetupProjection()
    {
        RenderTexture projectionTexture = new RenderTexture(width, height, depth, RenderTextureFormat.ARGB32);
        screen = projectionTexture;
        if (projection != null)
            projection.targetTexture = projectionTexture;
        screen.Create();
        if (projection != null)
        {
            projection.Render();
            unlit.mainTexture = projection.targetTexture;
            GetComponent<Renderer>().material.mainTexture = unlit.mainTexture;
        }
        if (!realtime) InvokeRepeating("UpdateProjection", 1f, updateRate);
    }

    private void Update()
    {
        if (realtime) UpdateProjection();
    }

    void UpdateProjection()
    {
        if (projection != null)
        {
            projection.targetTexture = screen;

            projection.Render();
        }
    }

}