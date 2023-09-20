using Assets.Scripts.MainMenu;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public class ButtonController : MonoBehaviour
	{
		public enum Type { Restart, GoToQuestion, GoToOrder, GoToMainMenu }
		[SerializeField] Type type;
		[SerializeField] Shelf shelf;
		public void Click()
		{
			switch (type)
			{
				case Type.Restart:
					GameManager.Instance.Restart();
					break;
				case Type.GoToQuestion:
					GameManager.Instance.StartQuestionGame(shelf.category);
					break;
				case Type.GoToOrder:
					GameManager.Instance.StartOrderGame(shelf.category);
					break;
				case Type.GoToMainMenu:
					GameManager.Instance.GoToMainMenu();
					break;
				default:
					break;
			}
		}
	}
}