using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
	public class Shelf : MonoBehaviour
	{
		public enum State { louck, question, order, finish }
		public State state;
		[SerializeField] bool defaultOpen;
		[SerializeField] Shelf[] connectedShelfe;

		//[SerializeField] 


	}
}