using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public PanelScript transitionPanel;

    //[SerializeField] bool ShowOutroAtStart;

    static bool firstOpen = true;

    private void Start()
    {

        transitionPanel.SetActive(true);
        transitionPanel.SetActive(false);

        //if (!firstOpen)
        //{
        //    transitionPanel.SetActive(true);
        //    transitionPanel.SetActive(false);
        //}
        //else
        //{
        //    firstOpen = false;
        //}
    }
}
