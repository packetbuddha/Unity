using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Chapter1
{
	public class MainText : MonoBehaviour {

		[SerializeField]
		private Text myText;

		private string welcomeText;
		private string treasureText;
		private int displayTimer = 3;

		void OnEnable ()
		{
			Treasure.TreasureTrigger += TreasureText;
		}

		void OnDisable ()
		{
			Treasure.TreasureTrigger -= TreasureText;
		}

		void Start ()
		{
			welcomeText = "Greetings Adventurer...\nYour mission is to steal the treasure and defeat all the enemies!";
			treasureText = "Foolish Adventurer! Now you will SUFFER!";

			WelcomeText();
		}

		void WelcomeText () 
		{
			StartCoroutine(DisplayCanvasTime(welcomeText));
		}

		void TreasureText ()
		{
			StartCoroutine(DisplayCanvasTime(treasureText));
		}

		void CanvasOn ()
		{
			gameObject.GetComponent<Canvas>().enabled = true;
		}

		void CanvasOff ()
		{
			gameObject.GetComponent<Canvas>().enabled = false;
		}

		IEnumerator DisplayCanvasTime (string displayText)
		{
			myText.text = displayText;
			CanvasOn();
			yield return new WaitForSeconds(displayTimer);
			CanvasOff();


		} 

	}
}

