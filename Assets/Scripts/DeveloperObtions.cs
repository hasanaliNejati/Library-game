using Question;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperObtions : MonoBehaviour
{

	public void ClearAllPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

	public void HelpInQuestions()
	{
		int corrent = PlayerPrefs.GetInt(QuestionGamePlayManager.KEY_DEVELOPERMOD);
		if (corrent != 0)
		{
			corrent = 0;
		}else
		{
			corrent = 1;
		}
		PlayerPrefs.SetInt(QuestionGamePlayManager.KEY_DEVELOPERMOD, corrent);
	}
}
