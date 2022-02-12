using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject player;
    public Camera camera;

    [SerializeField] private float cameraZoom;
    public float zoom {
        get {
            return cameraZoom;
        }
        set {
            var val = value;
            if (val <= 1)
                val = 1;
            else if (val >= 11.5f)
                val = 11.5f;

            Debug.Log("Changing zoom");
            camera.orthographicSize = val;
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
