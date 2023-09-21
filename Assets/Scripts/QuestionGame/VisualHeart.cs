using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Question
{
    public class VisualHeart : MonoBehaviour
    {
        [SerializeField] private Transform parent;

        [SerializeField] private GameObject heartObject;
        private List<GameObject> heartObjectList = new List<GameObject>();
        [Space(25),Header("Background Object")]
        [SerializeField] private Transform parentBackground;
        [SerializeField] private GameObject heartBackgroundObject;
        private List<GameObject> heartBackgroundObjectList = new List<GameObject>();

        public void Init(int numberHeart)
        {
            //print(numberHeart);
            foreach(var item in heartObjectList)
            {
                Destroy(item.gameObject);
            }
            for (int i = 0; i < numberHeart; i++)
            {

                var newItem = Instantiate(heartObject, parent);
                newItem.SetActive(true);
				heartObjectList.Add(newItem);
            }

            foreach (var item in heartBackgroundObjectList)
            {
                Destroy(item.gameObject);
            }
            for (int i = 0; i < numberHeart; i++)
            {
				var newItem = Instantiate(heartBackgroundObject, parentBackground);
				newItem.SetActive(true);
				heartBackgroundObjectList.Add(newItem);
            }
            QuestionGamePlayManager.Instance.OnFindMistalceWord += FindMistalceWord;
        }

        private void FindMistalceWord()
        {
            GameObject endHeartObject = heartObjectList[heartObjectList.Count - 1];
            heartObjectList.Remove(endHeartObject);
            Destroy(endHeartObject);
        }
    }
}