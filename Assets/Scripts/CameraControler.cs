
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControler : MonoBehaviour
{


    private static CameraControler _instance;
    public static CameraControler Instance { get { return _instance ? _instance : _instance = FindObjectOfType<CameraControler>(); } }




    [SerializeField] private Transform minX_minY;
    [SerializeField] private Transform maxX_maxY;


    [SerializeField] private float borderMoveSpeed = 5f;
    [SerializeField] private float borderThickness = 10f;




    private void OnDrawGizmos()
    {
        Debug.DrawLine(minX_minY.position, new Vector3(minX_minY.position.x, maxX_maxY.position.y));
        Debug.DrawLine(minX_minY.position, new Vector3(maxX_maxY.position.x, minX_minY.position.y));
        Debug.DrawLine(maxX_maxY.position, new Vector3(minX_minY.position.x, maxX_maxY.position.y));
        Debug.DrawLine(maxX_maxY.position, new Vector3(maxX_maxY.position.x, minX_minY.position.y));

    }

    private void Update()
    {
        MoveCameraWithMouse();
        Vector2 cameraPos = Camera.main.transform.position;


        Camera.main.transform.position = new Vector3(Mathf.Clamp(cameraPos.x, minX_minY.position.x, maxX_maxY.position.x), Mathf.Clamp(cameraPos.y, minX_minY.position.y, maxX_maxY.position.y), -10);
    }

    private void MoveCameraWithMouse()
    {

        Vector3 moveDirection = Vector3.zero;


        if (Input.mousePosition.y >= Screen.height - borderThickness)
        {
            moveDirection.y = 1;
        }

        else if (Input.mousePosition.y <= borderThickness)
        {
            moveDirection.y = -1;
        }

        if (Input.mousePosition.x >= Screen.width - borderThickness)
        {
            moveDirection.x = 1;
        }

        else if (Input.mousePosition.x <= borderThickness)
        {
            moveDirection.x = -1;
        }

        transform.position += moveDirection * borderMoveSpeed * Time.deltaTime;

    }



}

