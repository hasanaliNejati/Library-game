using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Documents : MonoBehaviour
{
	[SerializeField] List<GameObject> documents = new List<GameObject>();

	public void Active(int index)
	{
		if (index >= documents.Count)
			return;

		foreach (GameObject document in documents)
		{
			document.SetActive(false);
		}
		documents[index].SetActive(true);
	}


}
