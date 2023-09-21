using JetBrains.Annotations;
using Mvevd;
using System;
using System.Collections;
using UnityEngine;

namespace Question
{
    public class QuestionGamePlayManager : MonoBehaviour
    {

        public enum State
        {
            playing, End
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

        private State state;

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
            state = State.playing;

            maxNumberRight = questionLevel.maxRight;
            numberHeart = questionLevel.maxMistalce;

            questionLevel.ClaerPastNumberList();
            SetQuestion();
            Monitor.Instance.Init(question, maxNumberRight, numberHeart, timeBarWithAnyQuestion);
            Timer.SetTimer(KEY_TIMERBARE, () => Lose(), timeBarWithAnyQuestion);
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

            if (state == State.playing)
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
                    OnFindMistalceWord?.Invoke();

                    if (!Lose())
                    {
                        SetQuestion();
                    }

                }
            }


        }

        private bool Win()
        {
            if (state == State.playing)
            {
                if (numberRight == maxNumberRight)
                {
                    print("win");
                    OnWin();
                    state = State.End;

                    return true;
                }
            }
            return false;
        }

        private bool Lose()
        {
            if (state==State.playing)
            {
                if (numberHeart == 0)
                {
                    print("Lose");
                    OnLose();
                    state = State.End;

                    return true;
                }

            }  
            return false; 
        }


    }
}