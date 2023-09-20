using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Question
{
    public class QuestionLevel
    {
        [SerializeField] private int _maxMistalce;
        public int maxMistalce
        {
            get { return _maxMistalce; }
        }

        [SerializeField] private int _maxRight;
        public int maxRight
        {
            get { return _maxRight; }
        }

        [SerializeField] private List<Question> questionList;


        private List<int> pastNumberList = new List<int>();


        public Question GetQuestion(int id)
        {
            return questionList[id];
        }

        public Question GetRandomQuestion()
        {
            for (int i = 0; i < 1000; i++)
            {

                int targetId = Random.Range(0, questionList.Count);

                bool isNewIndex = true;
                foreach(int pastId in pastNumberList)
                {
                    if (pastId == targetId)
                    {
                        isNewIndex = false;
                        break;
                    }
                }

                if (isNewIndex)
                {
                    pastNumberList.Add(i);
                    return questionList[i];
                }

            }

            return null;

        }

        public void ClaerPastNumberList()
        {
            pastNumberList.Clear();
        }

    }
}