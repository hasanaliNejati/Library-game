using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
	public class ClickShelf_TPG : TutorialPartBase
	{

		[SerializeField] Button btn;
		[SerializeField] Vector3 cameraPosition;
		[SerializeField] Transform hower;
		private float speed = 10;

		private void Start()
		{
			btn.onClick.AddListener(OnBtnClick);
			if (Camera.main.GetComponent<CameraControler>())
				Camera.main.GetComponent<CameraControler>().enabled = false;
		}


		private void Update()
		{
			hower.transform.position = Camera.main.WorldToScreenPoint(btn.transform.position);

			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(cameraPosition.x, cameraPosition.y, Camera.main.transform.position.z), speed * Time.deltaTime);
		}


		void OnBtnClick()
		{
			if (Camera.main.GetComponent<CameraControler>())
				Camera.main.GetComponent<CameraControler>().enabled = true;
			btn.onClick.RemoveListener(OnBtnClick);
			Next();
		}

	}
}