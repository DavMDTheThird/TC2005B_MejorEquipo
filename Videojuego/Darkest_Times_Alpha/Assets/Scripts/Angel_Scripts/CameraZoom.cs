using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public bool ZoomActive;

    public Vector3[] Target;

    public Camera cam;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }


    public void LateUpdate()
    {
        if (ZoomActive)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6, Speed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 15, Speed);
        }
        
    }
}
