using Assets.Scripts;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	static GameManager _Instance;
	public static GameManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = FindObjectOfType<GameManager>();
				DontDestroyOnLoad(_Instance.gameObject);
			}
			return _Instance;
		}
	}

	private void Start()
	{
		if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	[Title("scenes")]
	[SerializeField] string MainMenuSceneName = "MainMenu";
	[SerializeField] string QuestionSceneName = "Question";
	[SerializeField] string OrderSceneName = "Order";
	[SerializeField] string StorySceneName = "Story";
	[SerializeField]
	float loadSceneDelay = 0.3f;

	public CategorySO category;

	public void StartQuestionGame(CategorySO category)
	{
		this.category = category;
		StartCoroutine(GoToScene(QuestionSceneName));
	}
	public void StartOrderGame(CategorySO category)
	{
		this.category = category;
		StartCoroutine(GoToScene(OrderSceneName));

	}
	public void GoToStory()
	{
		StartCoroutine(GoToScene(StorySceneName));
	}
	public void GoToMainMenu()
	{
		StartCoroutine(GoToScene(MainMenuSceneName));

	}

	public void Restart()
	{
		StartCoroutine(GoToScene(SceneManager.GetActiveScene().name));
	}

	IEnumerator GoToScene(string name)
	{
		FindObjectOfType<Transition>()?.transitionPanel.SetActive(true);
		yield return new WaitForSeconds(loadSceneDelay);
		SceneManager.LoadScene(name);
	}
}
