using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tutorial
{
    public class TutorialPartBase : MonoBehaviour
    {

        public UnityEvent OnNext = new UnityEvent();

        public void Init()
        {
            GetComponent<PanelScript>().SetActive(true);
        }


        protected void Next()
        {
            OnNext.Invoke();
            GetComponent<PanelScript>().SetActive(false);
        }
    }
}