using Assets.Scripts.MainMenu;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	[CreateAssetMenu(fileName = "category", menuName = "ScriptableObejcts/category", order = 0)]
	public class CategorySO : ScriptableObject
	{
		public string categoryName;
		[TextArea]
		public string categoryDescription;


		public void SaveState(Shelf.State state)
		{
			switch (state)
			{
				case Shelf.State.louck:
					PlayerPrefs.SetInt(categoryName, 0);
					break;
				case Shelf.State.question:
					PlayerPrefs.SetInt(categoryName, 1);
					break;
				case Shelf.State.order:
					PlayerPrefs.SetInt(categoryName, 2);
					break;
				case Shelf.State.finish:
					PlayerPrefs.SetInt(categoryName, 3);
					break;
				default:
					break;
			}
		}

	}
}