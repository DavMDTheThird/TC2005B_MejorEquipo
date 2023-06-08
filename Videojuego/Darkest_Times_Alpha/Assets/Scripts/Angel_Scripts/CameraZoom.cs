using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public bool ZoomActive;

    public Vector3[] Target;

    public Camera cam;

    public float Speed;

    public float Out;

    public Vector2 maxPosition;
    public Vector2 minPosition;

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
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, Out, Speed);
        }

        // Aplicar los límites del mapa
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minPosition.x, maxPosition.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minPosition.y, maxPosition.y);
        transform.position = clampedPosition;
    }
}
