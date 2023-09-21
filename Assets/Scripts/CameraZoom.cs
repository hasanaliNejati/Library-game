using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{


    [SerializeField] private float zoomOuMin = 1;
    [SerializeField] private float zoomOuMax = 8;
    [SerializeField] private float speed;

    private void Update()
    {
        MoveCameraWithMouse();
    }



    private void MoveCameraWithMouse()
    {
        Zoom(Input.GetAxis("Mouse ScrollWheel") * speed * Time.deltaTime);
    }

    private void Zoom(float increment)
    {

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOuMin, zoomOuMax);
    }
}