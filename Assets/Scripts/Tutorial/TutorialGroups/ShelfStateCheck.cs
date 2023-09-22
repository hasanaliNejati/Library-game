using Assets.Scripts.MainMenu;
using System.Collections;
using System.Collections.Generic;
using Tutorial;
using UnityEngine;

public class ShelfStateCheck : TutorialGroupBase
{
	[SerializeField] Shelf shelf;
	[SerializeField] Shelf.State state;

	[SerializeField] string singleShowSaveKey = "shelf 01";
	public override bool showCondition
	{
		get
		{
			if (shelf.state == state)
			{
				if (PlayerPrefs.GetInt(singleShowSaveKey) == 0)
				{
					PlayerPrefs.SetInt(singleShowSaveKey, 1);
					return true;
				}
			}
			return false;
		}
	}
}
