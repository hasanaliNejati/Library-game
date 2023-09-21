using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum State { Move,Stop }
    public State state;
    [SerializeField] Vector2 minPos;
    [SerializeField] Vector2 maxPos;
    [SerializeField] float speed = 5;
    [SerializeField] float speedZoom = 5;
	// Update is called once per frame
	void Update()
    {
        var ViewPortPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float targetPosX = minPos.x + ((maxPos.x - minPos.x) * ViewPortPos.x);
        float targetPosY = minPos.y + ((maxPos.y - minPos.y) * ViewPortPos.y);
        Vector3 targetPos = new Vector3 (targetPosX, targetPosY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);

		MoveCameraWithMouse();

	}

	private void OnDrawGizmos()
	{
		Vector2 point = minPos + ((maxPos - minPos) / 2);
        Gizmos.DrawWireCube(point, maxPos - minPos);
	}

	[SerializeField] private float zoomOuMin = 1;
	[SerializeField] private float zoomOuMax = 8;




	private void MoveCameraWithMouse()
	{
		Zoom(Input.GetAxis("Mouse ScrollWheel") * speedZoom * Time.deltaTime);
	}

	private void Zoom(float increment)
	{

		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOuMin, zoomOuMax);
	}
}
