using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgresbBarUi : MonoBehaviour
{
    [SerializeField] private bool upsideDown;
    [SerializeField] private float time;
    [SerializeField] private UnityEvent unityEvent;
    [SerializeField] private Image barUi;


    private bool end;
    private float deltaTime;

    private void OnEnable()
    {
        if (upsideDown)
        {
            deltaTime = time;
        }
        else
        {
            deltaTime = 0;
        }
    }

    private void Update()
    {
        if (!end)
        {
            if (upsideDown)
            {
                deltaTime -= Time.deltaTime;

            }
            else
            {
                deltaTime += Time.deltaTime;
            }

            barUi.fillAmount = deltaTime / time;

            if (upsideDown)
            {
                if (deltaTime <= 0)
                {
                    unityEvent?.Invoke();
                    end = true;
                }
            }
            else
            {
                if (deltaTime >= time)
                {
                    unityEvent?.Invoke();
                    end = true;
                }
            }
        }
    }

}
