using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Order
{
	[System.Serializable]
	public class BookData
	{
		public int category;
		public string title;
		[System.Serializable]
		public class VisibilityData
		{
			public float width;
			public Sprite sprite;
		}
		public VisibilityData visibility;
	}


}