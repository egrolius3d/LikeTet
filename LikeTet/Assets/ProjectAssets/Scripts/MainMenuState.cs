using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LikeTet
{
	public class MainMenuState : AppState {
		
		GameObject gameButton;
		GameObject newGameButton;
		GameObject exitButton;

		GameObject helpButton;
		GameObject rulesButton;
		GameObject aboutButton;

		public override void Activate (IStateData data, bool reset)
		{
			
			Debug.Log ("Activate main menu");

		}

		public  override void Initialize() // выполняется при запуске метод start
		{
			gameButton = GameObject.Find ("GameButton");
			exitButton = GameObject.Find ("ExitButton");
			newGameButton = GameObject.Find ("NewGameButton");
			helpButton = GameObject.Find ("HelpButton");
			rulesButton = GameObject.Find ("RulesButton");
			aboutButton = GameObject.Find ("AboutButton");

			gameButton.GetComponent<Button>().onClick.AddListener (OnClickGameButton);
			exitButton.GetComponent<Button>().onClick.AddListener (OnClickExitButton);
			newGameButton.GetComponent<Button>().onClick.AddListener (OnClickNewGameButton);

			helpButton.GetComponent<Button>().onClick.AddListener (OnClickHelpButton);
			rulesButton.GetComponent<Button>().onClick.AddListener (OnClickRulesButton);
			aboutButton.GetComponent<Button>().onClick.AddListener (OnClickAboutButton);


			newGameButton.SetActive (false);
			exitButton.SetActive (false);
			rulesButton.SetActive (false);
			aboutButton.SetActive (false);
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
			AppRoot.Instance.SetState (EAppStateId.MainMenu);
			newGameButton.SetActive (true);
			exitButton.SetActive (true);
		}

		public void OnClickNewGameButton()
		{
			newGameButton.SetActive (false);
			exitButton.SetActive (false);

			AppRoot.Instance.SetState (EAppStateId.Game);

			Debug.Log ("Pressed Game Button");
		}

		public void OnClickExitButton()
		{
			newGameButton.SetActive (false);
			exitButton.SetActive (false);
			Application.Quit();
		}

		public void OnClickHelpButton()
		{
			rulesButton.SetActive (true);
			aboutButton.SetActive (true);
		}

		public void OnClickRulesButton()
		{
			
			rulesButton.SetActive (false);
			aboutButton.SetActive (false);
		}

		public void OnClickAboutButton()
		{
			rulesButton.SetActive (false);
			aboutButton.SetActive (false);
		}

	}
}
