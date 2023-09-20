using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public static ButtonSound instance;
    [Header("If the component has audio,\n the audio become main audio for buttons sound")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool dontDestroyOnLoad;

    private void Start()
    {
        if (audioSource != null && instance == null)
        {
            instance = this;
            if (dontDestroyOnLoad)
            {
                transform.parent = null;
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    public void Play()
    {
        if (instance == this)
        {
            audioSource.Play();
        }
        else
        {
            instance.Play();
        }
    }



}
