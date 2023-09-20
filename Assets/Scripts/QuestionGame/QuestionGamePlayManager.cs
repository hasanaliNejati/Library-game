using JetBrains.Annotations;
using Mvevd;
using System;
using System.Collections;
using UnityEngine;

namespace Question
{
    public class QuestionGamePlayManager : MonoBehaviour
    {

        private const string KEY_TIMERBARE = "TimerBar";

        private static QuestionGamePlayManager _instance;
        public static QuestionGamePlayManager Instance
        {
            get
            {
                return _instance ? _instance : _instance = FindObjectOfType<QuestionGamePlayManager>();
            }
        }

        [SerializeField] private float timeBarWithAnyQuestion;

        [SerializeField] private QuestionLevel questionLevel;
        private Question question;


        public event Action OnFindRightWord;
        public event Action OnFindMistalceWord;
        public event Action OnWin;
        public event Action OnLose;



        private int numberRight;
        private int maxNumberRight;

        private int numberHeart;

        private void Start()
        {
            SetQuestion();
            Monitor.Instance.Init(question, maxNumberRight, numberHeart, timeBarWithAnyQuestion);
            Timer.SetTimer(KEY_TIMERBARE, () => Lose(), timeBarWithAnyQuestion);
        }

        private void SetQuestion()
        {
            question = questionLevel.GetRandomQuestion();
        }

        public void CheckTargetID(int targetID)
        {
            if (question.CheckIsTrueId(targetID))
            {
                numberRight++;
                OnFindRightWord?.Invoke();
                if (!Win())
                {
                    SetQuestion();
                }
            }
            else
            {
                numberHeart--;
                OnLose?.Invoke();

                if (!Lose())
                {
                    SetQuestion();
                }

            }
        }

        private bool Win()
        {
            if (numberRight == maxNumberRight)
            {
                print("win");
                OnWin();
                return true;
            }
            return false;
        }

        private bool Lose()
        {
            if(numberHeart == 0)
            {
                print("Lose");
                return true;
            }
            return false;
        }


    }
}