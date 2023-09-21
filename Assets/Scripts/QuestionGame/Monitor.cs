using System.Collections;
using UnityEngine;
using RTLTMPro;
using Assets.Scripts.QuestionGame;

namespace Question
{
    public class Monitor : MonoBehaviour
    {

        private static Monitor _instance;
        public static Monitor Instance
        {
            get
            {
                return _instance ? _instance : _instance = FindObjectOfType<Monitor>();
            }
        }

        [SerializeField] private RTLTextMeshPro description_TMP;

        [SerializeField] private BtnWord[] btnWordArray;

        [SerializeField] private PanelScript winPanel;
        [SerializeField] private PanelScript losePanel;

        [SerializeField] private VisualHeart visualHeart;
        [SerializeField] private VisualRightWord visualRightWord;

        [SerializeField] private ProgresbBarUi barUi;

        public void Init(Question question, int maxRight, int numberHeart, float barTime)
        {
            QuestionGamePlayManager.Instance.OnWin += Win;
            QuestionGamePlayManager.Instance.OnLose += Lose;
            Render(question,barTime);
            visualHeart.Init(numberHeart);
            visualRightWord.Init(maxRight);
            QuestionGamePlayManager.Instance.OnWin += barUi.Stop;
            QuestionGamePlayManager.Instance.OnLose += barUi.Stop;
        }
         


        public void Render(Question question,float timeBar)
        {

            question.OutData(out string description, out string[] optionArray);

            print(description);
            description_TMP.text = description;

            for (int i = 0; i < btnWordArray.Length; i++)
            {
                btnWordArray[i].Init(i, optionArray[i]);
            }

            barUi.Init(timeBar);

        }

        private void Lose()
        {
            losePanel.SetActive(true);
        }

        private void Win()
        {
            winPanel.SetActive(true);
        }
    }
}