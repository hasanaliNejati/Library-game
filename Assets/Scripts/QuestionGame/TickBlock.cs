using System.Collections;
using UnityEngine;

namespace Question
{
    public class TickBlock : MonoBehaviour
    {
        [SerializeField] private GameObject tickObject;
   

        public void Tick(bool isTick)
        {
            tickObject.SetActive(isTick);
        }
    }
}