﻿using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Order
{
	public class ShelfRow : MonoBehaviour
	{
		public static ShelfRow _Instance;
		public static ShelfRow Instance
		{
			get
			{
				return _Instance ? _Instance : _Instance = FindObjectOfType<ShelfRow>();
			}
		}

		BookObject draggingBook;

		[SerializeField] int bookCount = 10;
		[SerializeField] BookObject bookObejct;
		List<BookObject> _books = new List<BookObject>();
		[SerializeField] CameraSizeManager cameraSizeManager;

		[Title("UI")]
		[SerializeField] PanelScript winPanel;
		[Title("Sound")]
		[SerializeField] AudioClip startDrageAudio;
		[SerializeField] AudioClip DropAudio;
		[SerializeField] AudioClip OnDraggingBookIndexChegedAudio;
		[SerializeField] float changePlayDelay = 0.2f;
		[SerializeField] AudioClip WinAudio;



		int lastDraggingBookIndex = -1;
		private void Start()
		{
			Init();
		}

		void Init()
		{
			var newAllBookList = new List<BookData>();
			newAllBookList.AddRange(GameManager.Instance.category.booksData);
			var RandomBookDataList = new List<BookData>();
			if (newAllBookList.Count < bookCount)
			{
				Debug.LogError("book not enogh");
				return;
			}
			for (int i = 0; i < bookCount; i++)
			{
				int index = Random.Range(0, newAllBookList.Count);
				RandomBookDataList.Add(newAllBookList[index]);
				newAllBookList.RemoveAt(index);
			}

			foreach (var item in RandomBookDataList)
			{
				var newObject = Instantiate(bookObejct);
				newObject.Init(item);
				_books.Add(newObject);
			}

			float width = CalculatePos();
			cameraSizeManager.targetWidth = width + 2;
			cameraSizeManager.Start();
			cameraSizeManager.transform.position += new Vector3(width / 2, 0, 0);
		}
		float changeIndexSoundTime;
		public float CalculatePos()
		{
			float offsetX = 0;
			int draggingBookIndex = -1;
			if (draggingBook)
			{
				draggingBookIndex = GetIndex(draggingBook.pos.x);
				if (lastDraggingBookIndex != -1 && lastDraggingBookIndex != draggingBookIndex && Time.time > changeIndexSoundTime)
				{
					AudioSource.PlayClipAtPoint(OnDraggingBookIndexChegedAudio, Camera.main.transform.position);
					changeIndexSoundTime = Time.time + changePlayDelay;
				}
			}
			lastDraggingBookIndex = draggingBookIndex;
			BookObject lastObject = null;
			for (int i = 0; i < _books.Count; i++)
			{
				if (draggingBookIndex == i)
				{
					draggingBook.pos = new Vector2(offsetX, 0);
					if (lastObject)
						offsetX += (draggingBook.data.visibility.width / 2) + (lastObject.data.visibility.width / 2);
					lastObject = draggingBook;
				}
				if (lastObject)
					offsetX += (_books[i].data.visibility.width / 2) + (lastObject.data.visibility.width / 2);
				_books[i].pos = new Vector2(offsetX, 0);
				lastObject = _books[i];
			}
			return offsetX;
		}
		public int GetIndex(float posX)
		{
			for (int i = 0; i < _books.Count; i++)
			{
				if (_books[i].pos.x > posX)
				{
					return i;
				}
			}
			return _books.Count;
		}
		public void StartDragging(BookObject book)
		{
			_books.Remove(book);
			draggingBook = book;
			AudioSource.PlayClipAtPoint(startDrageAudio, Camera.main.transform.position);
		}
		public void Drop(BookObject book)
		{
			_books.Insert(GetIndex(book.pos.x), book);
			draggingBook = null;
			AudioSource.PlayClipAtPoint(DropAudio, Camera.main.transform.position);

			CalculatePos();
			CheckWin();
		}

		private void Update()
		{
			if (draggingBook)
			{
				CalculatePos();
			}
		}

		public void CheckWin()
		{
			float last = 0;
			foreach (var item in _books)
			{
				if (item.data.category < last)
				{
					return;
				}
				last = item.data.category;
			}
			//win
			print("win");
			winPanel.SetActive(true);
			AudioSource.PlayClipAtPoint(WinAudio, Camera.main.transform.position);
			GameManager.Instance.category.SaveState(MainMenu.Shelf.State.finish);

		}
	}
}