using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Question
{
    [Serializable]
    public class Question
    {

        [SerializeField] private string description;
        [SerializeField] private string[] optionArray = new string[4];

        [SerializeField] private int trueID;

        public bool CheckIsTrueId(int id)
        {
            return trueID == id;
        }


        public void OutData(out string description, out string[] optionArray)
        {
            description = this.description;
            optionArray = this.optionArray;
        }
    }
}