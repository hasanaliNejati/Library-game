using Question;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.QuestionGame
{
    public class VisualRightWord : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private TickBlock tickBlock;
        private List<TickBlock> tickBlockList = new List<TickBlock>();


        public void Init(int numberRight)
        {

            foreach (Transform item in parent)
            {
                Destroy(item.gameObject);
            }

            for (int i = 0; i < numberRight; i++)
            {
                tickBlockList.Add(Instantiate(tickBlock, parent));
            }

            QuestionGamePlayManager.Instance.OnFindRightWord += FindRightWord;

        }

        private void FindRightWord()
        {
            tickBlockList[tickBlockList.Count-1].Tick(true);
            tickBlockList.RemoveAt(tickBlockList.Count - 1);
        }
    }
}