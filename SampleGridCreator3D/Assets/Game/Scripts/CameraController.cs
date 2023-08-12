using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        UpdateCameraSize();
    }

    private void Update()
    {
        //UpdateCameraSize();
    }

    private void UpdateCameraSize()
    {
        float screenHeight = Screen.height;
        float targetSize = screenHeight *0.0025f; // İstediğiniz oranı belirleyebilirsiniz

        mainCamera.orthographicSize = targetSize;
    }
}
