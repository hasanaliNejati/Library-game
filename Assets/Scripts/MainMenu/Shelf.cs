using Sirenix.OdinInspector;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.MainMenu
{
	public class Shelf : MonoBehaviour
	{
		public enum State { louck, question, order, finish }
		public State state;
		[SerializeField] bool defaultOpen;
		[SerializeField] Shelf[] connectedShelfs;
		public CategorySO category;
		[SerializeField] PanelScript QuestionPanel;
		[SerializeField] PanelScript OrderPanel;
		[SerializeField] PanelScript FinishPanel;
		[Title("Graphic")]
		[SerializeField] ShelfStateGraphics shelfGraphic;
		[SerializeField] TextMeshProUGUI[] nameTexts;
		[SerializeField] TextMeshProUGUI[] describeTexts;
		[SerializeField] UnityEvent OnClick;
		bool inited;
		void Awake()
		{
			if (!inited)
				Init();
		}
		public void Init()
		{
			inited = true;
			int savedNum = PlayerPrefs.GetInt(category.categoryName);
			switch (savedNum)
			{
				case 0:
					state = State.louck;
					break;
				case 1:
					state = State.question;
					break;
				case 2:
					state = State.order;
					break;
				case 3:
					state = State.finish;
					break;
				default:
					state = State.finish;
					break;
			}
			if (defaultOpen && state == State.louck)
				state = State.question;

			if (state == State.louck)
				foreach (var item in connectedShelfs)
				{
					if (!item.inited)
						item.Init();
					if (item.state == State.finish)
					{
						state = State.question;
					}
				}

			shelfGraphic.SetActive(state);

			foreach (var item in nameTexts)
			{
				item.text = category.categoryName;
			}
			foreach (var item in describeTexts)
			{
				item.text = category.categoryDescription;
			}
		}

		public void Click()
		{
			switch (state)
			{
				case State.louck:
					break;
				case State.question:
					QuestionPanel.SetActive(true);
					break;
				case State.order:
					OrderPanel.SetActive(true);
					break;
				case State.finish:
					FinishPanel.SetActive(true);
					break;
				default:
					break;
			}
			OnClick.Invoke();

		}



	}

}