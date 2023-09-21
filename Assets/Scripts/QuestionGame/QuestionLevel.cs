using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Question
{
    [Serializable]
    public class QuestionLevel
    {
        public int maxMistalce;

        public int maxRight;

        public List<Question> questionList;


        private List<int> pastNumberList = new List<int>();


        public Question GetQuestion(int id)
        {
            return questionList[id];
        }

        public Question GetRandomQuestion()
        {
            for (int i = 0; i < 1000; i++)
            {

                int targetId =UnityEngine.Random.Range(0, questionList.Count);

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
                    pastNumberList.Add(targetId);
                    return questionList[targetId];
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