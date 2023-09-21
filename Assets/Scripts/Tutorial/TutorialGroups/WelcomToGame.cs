using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class WelcomToGame : TutorialGroupBase
    {


        string savekey = "FirstOpen_welcom panel";
        public override bool showCondition
        {
            get
            {
                if (gameObject.activeSelf == true)
                    return false;

                var outpot = PlayerPrefs.GetInt(savekey) == 0;
                if (outpot)
                    PlayerPrefs.SetInt(savekey, 1);


                return outpot;
            }
        }
    }
}