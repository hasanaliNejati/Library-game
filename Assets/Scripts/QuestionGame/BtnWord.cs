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
            id = index;
            rtlTextMeshPro.text = option;
        }


        public void Click()
        {
            QuestionGamePlayManager.Instance.CheckTargetID(id);
            SetColor(Color.red);
        }

        public void SetColor(Color color)
        {
            background.color = color;
        }

    }
}