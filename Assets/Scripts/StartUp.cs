using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{

    [SerializeField] string gameSceneName = "MainMenu";
    [SerializeField] string storySceneName = "Story";
    [SerializeField] float startDelay = 2f;

    string saveKey = "one show story";
    // Start is called before the first frame update
    IEnumerator Start()
    {
        
        yield return new WaitForSeconds(startDelay);
        if (PlayerPrefs.GetInt(saveKey) == 0)
        {
            PlayerPrefs.SetInt(saveKey, 1);
            SceneManager.LoadScene(storySceneName);

        }else
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
