using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeManager : MonoBehaviour
{
    public float targetWidth = 4;
    Camera camera;

    public void Start()
    {
        camera = Camera.main;
        float height = camera.orthographicSize * 2;
        float width = height * camera.aspect;
        if(width < targetWidth)
        camera.orthographicSize = (targetWidth / width) * camera.orthographicSize;
    }

    //private void Update()
    //{
        

    //    //if(Input.GetKeyDown(KeyCode.Space))
    //        camera.orthographicSize = (targetWidth / width) * camera.orthographicSize;
    //    print(height);
    //    print(width);
    //}
}
