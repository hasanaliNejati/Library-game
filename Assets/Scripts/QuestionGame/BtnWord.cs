using System.Collections;
using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;

namespace Question
{
    public class BtnWord : MonoBehaviour
    {

        [SerializeField] private RTLTextMeshPro rtlTextMeshPro;
        [SerializeField] private Image background;
        private int id;

        public void Init(int index, string option)
        { 
            SetColor(Color.white);
            if (index == 0)
            {
                if (PlayerPrefs.GetInt(QuestionGamePlayManager.KEY_DEVELOPERMOD, 0) == 1)
                {
                    SetColor(Color.gray);
                }
            }

            id = index;
            rtlTextMeshPro.text = option;
        }


        public void Click()
        { 
            SetColor(Color.red);
            QuestionGamePlayManager.Instance.CheckTargetID(id);

        }

        public void SetColor(Color color)
        {
            background.color = color;
        }

    }
}