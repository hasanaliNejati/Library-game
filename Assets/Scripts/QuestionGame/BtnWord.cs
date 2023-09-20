using System.Collections;
using UnityEngine;
using RTLTMPro;

namespace Question
{
    public class BtnWord : MonoBehaviour
    {

        [SerializeField] private RTLTextMeshPro rtlTextMeshPro;
        private int id;

        public void Init(int index, string option)
        {
            id = index;
            rtlTextMeshPro.text = option;
        }


        public void Click()
        {
            QuestionGamePlayManager.Instance.CheckTargetID(id);
        }

    }
}