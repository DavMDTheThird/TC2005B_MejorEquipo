using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutHospital : MonoBehaviour
{
    public Camera mainCamera;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            CameraZoom cameraZoom = mainCamera.GetComponent<CameraZoom>();
            if (cameraZoom != null)
            {
                cameraZoom.ZoomActive = false;
                cameraZoom.Out = 10;
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

