using System.Collections;
using UnityEngine;

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


        [SerializeField] private BtnWord[] btnWordArray;

        [SerializeField] private PanelScript winPanel;
        [SerializeField] private PanelScript losePanel;


        public void Init(Question question, int maxRight, int numberHeart, float barTime)
        {

        }
    }
}