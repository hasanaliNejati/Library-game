using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Question
{
    [Serializable]
    public class Question
    {

        public string description;
       public List<string> optionArray = new List<string>();



        public void OutData(out string description, out List<string> optionArray)
        {
            description = this.description;
            optionArray = this.optionArray;
        }
    }
}