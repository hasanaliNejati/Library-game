using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
	public class ShelfStateGraphics : MonoBehaviour
	{
		[SerializeField] SpriteRenderer spriteRenderer;
		[SerializeField] Color blackColor = Color.black;
		[SerializeField] GameObject louckObject;
		[SerializeField] GameObject QuestionObject;
		[SerializeField] GameObject OrderObject;


		public void SetActive(Shelf.State state)
		{
			switch (state)
			{
				case Shelf.State.louck:
					spriteRenderer.color = blackColor;
					louckObject.SetActive(true);
					break;
				case Shelf.State.question:
					QuestionObject.SetActive(true);
					break;
				case Shelf.State.order:
					OrderObject.SetActive(true);
					break;
				case Shelf.State.finish:
					break;
				default:
					break;
			}
		}

	}
}