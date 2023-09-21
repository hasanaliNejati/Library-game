using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class TutorialGroupBase : MonoBehaviour
    {

        public virtual bool showCondition
        {
            get { return false; }
        }

        [SerializeField] List<TutorialPartBase> partList = new List<TutorialPartBase>();

        int index;

        private void OnEnable()
        {
            Enable();
        }

        internal virtual void Enable()
        {

            //first show
            ShowTutorialPart();
        }

        void Next()
        {
            //partList[index].OnNext.RemoveListener(Next);
            index++;
            if (index < partList.Count)
            {
                ShowTutorialPart();
            }
            else
            {
                Disable();
            }
        }

        void ShowTutorialPart()
        {
            //Add next listener
            partList[index].OnNext.AddListener(Next);

            partList[index].Init();
        }

        internal virtual void Disable()
        {
            gameObject.SetActive(false);
        }

    }
}