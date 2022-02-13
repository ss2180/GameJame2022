using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public Camera fluidCam;
    public GameObject fluidView;

    [SerializeField] private float cameraZoom;
    public float zoom {
        get {
            return cameraZoom;
        }
        set {
            var val = value;
            if (val <= 5)
                val = 5;
            else if (val >= 11.5f)
                val = 11.5f;

            camera.orthographicSize = val;
            fluidCam.orthographicSize = val;
            fluidView.transform.localScale = new Vector3(((val * 2) / 9f) * 16, val * 2, 1);
            cameraZoom = val;
        }
    }

    private void Start()
    {
        zoom = 5;
    }

    private void OnValidate()
    {
        zoom = cameraZoom;
    }

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.z = -10;
        transform.position = pos;
    }
}
