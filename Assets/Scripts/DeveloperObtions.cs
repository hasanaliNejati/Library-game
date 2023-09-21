using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperObtions : MonoBehaviour
{

	public void ClearAllPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}
}
