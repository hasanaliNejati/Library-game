using JetBrains.Annotations;
using Mvevd;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;

namespace Question
{
	public class QuestionGamePlayManager : MonoBehaviour
	{

		public enum State
		{
            Expectation, playing, End
		}

		private const string KEY_TIMERBARE = "TimerBar";

		private static QuestionGamePlayManager _instance;
		public static QuestionGamePlayManager Instance
		{
			get
			{
				return _instance ? _instance : _instance = FindObjectOfType<QuestionGamePlayManager>();
			}
		}

		private State state=State.Expectation;
		[SerializeField] PanelScript questionBoxPanel;
		[SerializeField] private float timeBarWithAnyQuestion;
		[SerializeField] float nextQuestionDelay = 0.5f;
		[SerializeField] float endGameDelay = 0.5f;
		[SerializeField] GameObject ClickBlocker;

		[Title("SoundEffect")]
		public AudioClip rightAnswerSound;
		public AudioClip wrongAnswerSound;
		public AudioClip nextQuestionSound;
		public AudioClip FinishTimeSound;
		public AudioClip WinSound;
		public AudioClip LoseSound;




		QuestionLevel questionLevel { get { return GameManager.Instance.category.questionLevel; } }
		private Question question;

		public event Action CheckId;
		public event Action OnFindRightWord;
		public event Action OnFindMistalceWord;
		public event Action OnWin;
		public event Action OnLose;




		private int numberRight;
		private int maxNumberRight;

		private int numberHeart;

		public void Init()
		{
			state = State.playing;

			maxNumberRight = questionLevel.maxRight;
			numberHeart = questionLevel.maxMistalce;

			questionLevel.ClaerPastNumberList();
			SetQuestion();
			Monitor.Instance.Init(question, maxNumberRight, numberHeart, timeBarWithAnyQuestion);
		}

		private void SetQuestion()
		{
			bool isFirs = question == null;
			question = questionLevel.GetRandomQuestion();
			if (!isFirs)
			{
				Monitor.Instance.Render(question, timeBarWithAnyQuestion);
			}

		}

		public void CheckTargetID(int targetID)
		{

			FindObjectOfType<ProgresbBarUi>().Stop();
			if (state == State.playing)
			{
				CheckId?.Invoke();

                if (question.CheckIsTrueId(targetID))
				{
					numberRight++;
					OnFindRightWord?.Invoke();
					AudioSource.PlayClipAtPoint(rightAnswerSound, Camera.main.transform.position);
					
					if (!Win())
						NextQuestion();

				}
				else
				{
					AudioSource.PlayClipAtPoint(wrongAnswerSound, Camera.main.transform.position);

					Mistake();
				}
			}
		}

		public void EndTime()
		{
			AudioSource.PlayClipAtPoint(FinishTimeSound, Camera.main.transform.position);
			Mistake();
		}

		void Mistake()
		{
			numberHeart--;
			OnFindMistalceWord?.Invoke();

			if (!Lose())
			{
				NextQuestion();
			}
		}

		public void NextQuestion()
		{

			StartCoroutine(_NextQuestion());
		}
		IEnumerator _NextQuestion()
		{
			ClickBlocker.SetActive(true);

			AudioSource.PlayClipAtPoint(nextQuestionSound, Camera.main.transform.position);
			questionBoxPanel.SetActive(false);
			yield return new WaitForSeconds(nextQuestionDelay);
			questionBoxPanel.SetActive(true);
			SetQuestion();
			ClickBlocker.SetActive(false);

		}

		private bool Win()
		{
			if (state == State.playing)
			{
				if (numberRight == maxNumberRight)
				{
					GameManager.Instance.category.SaveState(Assets.Scripts.MainMenu.Shelf.State.order);
					print("win");
					state = State.End;
					AudioSource.PlayClipAtPoint(WinSound, Camera.main.transform.position);
					OnWin();
					return true;
				}
			}
			return false;
		}

		private bool Lose()
		{
			if (state == State.playing)
			{
				if (numberHeart == 0)
				{
					print("Lose");

					state = State.End;
					AudioSource.PlayClipAtPoint(LoseSound, Camera.main.transform.position);
					OnLose();

					return true;
				}

			}
			return false;
		}


	}
}