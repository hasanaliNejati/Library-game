using Sirenix.OdinInspector;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Order
{
	public class BookObject : MonoBehaviour
	{
		public enum State { stay, draging }
		public State state;
		public BookData data;
		[SerializeField] SpriteRenderer spriteRenderer;
		[SerializeField] float speed = 5;
		[SerializeField] Animator anim;
		[SerializeField] Transform button;
		public Vector2 pos;
		[Title("Texts")]
		public TextMeshPro categoryText;
		public TextMeshPro autherText;
		public TextMeshPro nameText;
		public void Init(BookData data)
		{
			this.data = data;
			if(data.visibility.sprite != null)
			spriteRenderer.sprite = data.visibility.sprite;
			spriteRenderer.size = new Vector2(data.visibility.width, spriteRenderer.size.y);
			button.localScale = new Vector3(data.visibility.width,button.localScale.y);
			//spriteRenderer.transform.localPosition = new Vector3(data.visibility.width / 2, 0);
			categoryText.text = data.category.ToString().Replace('.','/');
			autherText.text = data.auther;

			nameText.text = data.title;
		}

		private void Update()
		{
			if (state == State.stay)
				transform.position = Vector2.Lerp(transform.position, pos, speed * Time.deltaTime);
			else
			{

				pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.position = Vector2.Lerp(transform.position, pos, speed * Time.deltaTime);
			}
		}

		public void OnDrag()
		{
			ShelfRow.Instance.StartDragging(this);
			anim.SetBool("dragging", true);
			state = State.draging;
		}
		public void OnDrop()
		{
			ShelfRow.Instance.Drop(this);
			anim.SetBool("dragging", false);

			state = State.stay;
			
		}
	}
}