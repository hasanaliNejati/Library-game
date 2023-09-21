using Assets.Scripts;
using Assets.Scripts.Order;
using Question;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Category initializer", menuName = "ScriptableObejcts/categoryIniter", order = 0)]
public class CategoryGeneratorSO : ScriptableObject
{
	[SerializeField] CategorySO category;
	[SerializeField] TextAsset questionDataText;
	[SerializeField] TextAsset booksDataText;
	[Title("Question")]
	[SerializeField] int maxRight = 7;
	[SerializeField] int maxMistake = 3;
	[Title("Order")]
	[SerializeField]
	BookData.VisibilityData[] visibilities;
	//[SerializeField] List<Sprite> bookSprites = new List<Sprite>();
	//[SerializeField] float minSize = 0.8f;
	//[SerializeField] float maxSize = 2.5f;

	[Button("GenerateLevel")]
	public void GenerateLevel()
	{



		#region question
		QuestionLevel questionLevel = new QuestionLevel();
		questionLevel.maxMistalce = maxMistake;
		questionLevel.maxRight = maxRight;
		var questionList = new List<Question.Question>();
		string[] lines = questionDataText.text.Split('\n');
		Question.Question correntQuestion = null;
		foreach (string item in lines)
		{
			string line = item;
			//if (item.Split('\t').Length > 1)
			//	line = item.Split("\t")[0];

			if (string.IsNullOrEmpty(line) || line.Length < 2)
			{
				if (correntQuestion != null)
					questionList.Add(correntQuestion);
				correntQuestion = null;
				continue;
			}
			if (correntQuestion == null)
			{
				correntQuestion = new Question.Question();
				correntQuestion.description = line;
				continue;
			}
			correntQuestion.optionArray.Add(line);
		}
		if (correntQuestion != null)
		{
			questionList.Add(correntQuestion);
		}
		questionLevel.questionList = questionList;
		category.questionLevel = questionLevel;
		#endregion

		#region books
		string[] bookDataLines = booksDataText.text.Split('\n');
		List<BookData> bookDataList = new List<BookData>();
		foreach (var item in bookDataLines)
		{
			string[] data = new string[3];
			var itemColumns = item.Split("\t");
			for (int i = 0; i < itemColumns.Length; i++)
			{
				if (i >= 3)
					break;
				data[i] = itemColumns[i];
			}

			var newBookData = new BookData();
			newBookData.title = data[0];
			newBookData.category = float.Parse(data[1]);
			newBookData.auther = data[2];

			newBookData.visibility = visibilities[Random.Range(0, visibilities.Length)];

			//newBookData.visibility = new BookData.VisibilityData
			//{
			//	sprite = bookSprites[Random.Range(0, bookSprites.Count)],
			//	width = Random.Range(minSize, maxSize)
			//};

			bookDataList.Add(newBookData);
		}
		category.booksData = bookDataList;
		#endregion

		Debug.Log("maked");
	}

}