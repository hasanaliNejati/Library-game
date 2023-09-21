using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
    public class UIClick_TPG : TutorialPartBase
    {
        [SerializeField] Button btn;
        [SerializeField] Transform hower;
        [SerializeField] int clickCount = 1;
        int _clickCount = 0;
        private void Start()
        {
            btn.onClick.AddListener(OnBtnClick);
            if (!btn.gameObject.activeInHierarchy)
            {
                OnBtnClick();
            }
        }
        

        private void Update()
        {
            hower.transform.position = btn.transform.position;
        }

        void OnBtnClick()
        {
            _clickCount++;
            if (_clickCount < clickCount)
                return;
            btn.onClick.RemoveListener(OnBtnClick);
            Next();
        }

    }
}