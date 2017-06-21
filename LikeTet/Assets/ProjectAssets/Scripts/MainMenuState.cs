using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LikeTet
{
	public class MainMenuState : AppState {

		GameObject gameButton;
		GameObject helpButton;

		public override void Activate (IStateData data, bool reset)
		{
			
			Debug.Log ("Activate main menu");

		}

		public  override void Initialize() // выполняется при запуске метод start
		{
			gameButton = GameObject.Find ("GameButton");
			gameButton.GetComponent<Button>().onClick.AddListener (OnClickGameButton);

			Debug.Log("Initialize main menu state");
			// mId = EAppStateId.Game;

		}

		public override void Update ()
		{


			if (Input.GetKeyDown (KeyCode.LeftShift)) 
			{
				AppRoot.Instance.SetState (EAppStateId.Game);
			}

			Debug.Log ("Update from Main Menu");
		}
		public void OnClickGameButton()
		{
			AppRoot.Instance.SetState (EAppStateId.Game);

			Debug.Log ("Pressed Game Button");
		}
	}
}
