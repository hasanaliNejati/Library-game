using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{

	[SerializeField] float storyLenght = 120;
	[SerializeField] string gameSceneName = "MainMenu";
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(storyLenght);
		FinishStory();
	}

	public void FinishStory()
	{

		SceneManager.LoadScene(gameSceneName);
	}

}
