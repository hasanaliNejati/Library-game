using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	[CreateAssetMenu(fileName = "category",menuName = "ScriptableObejcts/category",order = 0)]
	public class CategorySO : ScriptableObject
	{
		public string categoryName;
		[TextArea]
		public string categoryDescription;


	}
}