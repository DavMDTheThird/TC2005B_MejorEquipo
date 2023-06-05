using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public Camera mainCamera;

    public float Speed;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CameraZoom cameraZoom = mainCamera.GetComponent<CameraZoom>();
            if (cameraZoom != null)
            {
                cameraZoom.ZoomActive = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CameraZoom cameraZoom = mainCamera.GetComponent<CameraZoom>();
            if (cameraZoom != null)
            {
                cameraZoom.ZoomActive = true;
            }
        }
    }

}

