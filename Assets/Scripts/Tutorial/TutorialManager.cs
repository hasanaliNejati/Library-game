using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class TutorialManager : MonoBehaviour
    {


        [SerializeField] List<TutorialGroupBase> tutorials = new List<TutorialGroupBase>();
        [SerializeField] bool CheckInUpdate = false;


        private void Start()
        {
            foreach (var tutorial in tutorials)
            {
                if (tutorial.showCondition)
                {
                    print("tutorial");
                    tutorial.gameObject.SetActive(true);
                    print("tutorial1");

                }
            }
        }

        private void Update()
        {
            if (!CheckInUpdate)
                return;
            foreach (var tutorial in tutorials)
            {
                if (tutorial.showCondition)
                {
                    tutorial.gameObject.SetActive(true);
                }
            }
        }
    }
}