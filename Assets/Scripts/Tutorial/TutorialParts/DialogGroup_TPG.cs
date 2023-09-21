using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial
{
	public class DialogGroup_TPG : TutorialPartBase
	{

		[SerializeField] TextMeshProUGUI dialogText;
		[SerializeField] Image dialogImage;
		[SerializeField] Image dialogImage2;
		[SerializeField] AudioSource dialogAudioSource;
		[System.Serializable]
		class DialogDetail
		{
			[TextArea]
			[SerializeField] internal string massage;
			[SerializeField] internal bool image1Active = true;
			[SerializeField] internal bool image2Active;
			[SerializeField] internal Sprite customImage;
			[SerializeField] internal Sprite customImage2;
			[SerializeField] internal AudioClip soundClip;
		}
		[SerializeField] List<DialogDetail> dialogList = new List<DialogDetail>();

		int index;


		private void Start()
		{
			ShowDialog();
		}

		public void NextDialog()
		{
			if (index < dialogList.Count - 1)
			{
				//print("show dialog");
				index++;
				ShowDialog();
			}
			else
			{
				//print("end Dialoging");
				Next();
			}
		}


		void ShowDialog()
		{
			dialogText.text = dialogList[index].massage;
			if (dialogList[index].customImage != null)
				dialogImage.sprite = dialogList[index].customImage;
			if (dialogList[index].customImage2 != null)
				dialogImage2.sprite = dialogList[index].customImage2;

			dialogImage.gameObject.SetActive(dialogList[index].image1Active);
			dialogImage2.gameObject.SetActive(dialogList[index].image2Active);

			if (dialogAudioSource != null)
			{
				dialogAudioSource.Stop();
				if (dialogList[index].soundClip != null)
				{

					dialogAudioSource.clip = dialogList[index].soundClip;
					dialogAudioSource.Play();

				}
			}
		}


	}
}