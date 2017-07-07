using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LikeTet
{
	public class MainMenuState : AppState {
		///////////////////////////////////////////////////////////////////////////
		#region Variables
		GameObject gameButton;
		GameObject newGameButton;
		GameObject exitButton;

		GameObject helpButton;
		GameObject rulesButton;
		GameObject aboutButton;
		GameObject okRulesButton;
		GameObject okAboutButton;

		GameObject mainMenuPanel;
		GameObject rulesPanel;
		GameObject aboutPanel;

		GameObject gridMain;
		GameObject backgroundGrid;
		#endregion
		///////////////////////////////////////////////////////////////////////////
	
		///////////////////////////////////////////////////////////////////////////
		#region Implementation
		public override void Activate (IStateData data, bool reset)
		{
			mId = EAppStateId.MainMenu;
			Debug.Log ("Activate main menu");

		}

		public  override void Initialize() // выполняется при запуске 
		{

			gameButton = GameObject.Find ("GameButton");
			exitButton = GameObject.Find ("ExitButton");
			newGameButton = GameObject.Find ("NewGameButton");
			helpButton = GameObject.Find ("HelpButton");
			rulesButton = GameObject.Find ("RulesButton");
			aboutButton = GameObject.Find ("AboutButton");
			okAboutButton = GameObject.Find ("OkAboutButton");
			okRulesButton = GameObject.Find ("OkRulesButton");

			mainMenuPanel = GameObject.Find ("MainMenuPanel");
			rulesPanel = GameObject.Find ("RulesPanel");
			aboutPanel = GameObject.Find ("AboutPanel");

			gridMain = GameObject.Find ("Grid");
			backgroundGrid = GameObject.Find ("BackgroundGrid");
	

			gameButton.GetComponent<Button>().onClick.AddListener (OnClickGameButton);
			exitButton.GetComponent<Button>().onClick.AddListener (OnClickExitButton);
			newGameButton.GetComponent<Button>().onClick.AddListener (OnClickNewGameButton);

			helpButton.GetComponent<Button>().onClick.AddListener (OnClickHelpButton);
			rulesButton.GetComponent<Button>().onClick.AddListener (OnClickRulesButton);
			aboutButton.GetComponent<Button>().onClick.AddListener (OnClickAboutButton);

			okRulesButton.GetComponent<Button> ().onClick.AddListener (OnClickOkRulesAbouButton);
			okAboutButton.GetComponent<Button> ().onClick.AddListener (OnClickOkRulesAbouButton);

			aboutPanel.SetActive (false);
			rulesPanel.SetActive (false);

			newGameButton.SetActive (false);
			exitButton.SetActive (false);
			rulesButton.SetActive (false);
			aboutButton.SetActive (false);

			gridMain.SetActive (true);
			backgroundGrid.SetActive (true);
			Debug.Log("Initialize main menu state");

		}

		///////////////////////////////////////////////////////////////////////////
		public override void Update ()
		{


			if (Input.GetKeyDown (KeyCode.LeftShift)) 
			{
				AppRoot.Instance.SetState (EAppStateId.Game);
			}

			Debug.Log ("Update from Main Menu");
		}
		///////////////////////////////////////////////////////////////////////////
		public void OnClickGameButton()
		{
			AppRoot.Instance.SetState (EAppStateId.MainMenu);
			newGameButton.SetActive (true);
			exitButton.SetActive (true);
			aboutButton.SetActive (false);
			rulesButton.SetActive (false);
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
			AppRoot.Instance.SetState (EAppStateId.MainMenu);
			newGameButton.SetActive (false);
			exitButton.SetActive (false);
			rulesButton.SetActive (true);
			aboutButton.SetActive (true);
		}

		public void OnClickRulesButton()
		{
			gridMain.SetActive (false);
			backgroundGrid.SetActive (false);
			mainMenuPanel.SetActive (false);

			rulesPanel.SetActive (true);
			rulesButton.SetActive (false);
			aboutButton.SetActive (false);
		}

		public void OnClickAboutButton()
		{
			gridMain.SetActive (false);
			backgroundGrid.SetActive (false);
			mainMenuPanel.SetActive (false);
			aboutPanel.SetActive (true);
			rulesButton.SetActive (false);
			aboutButton.SetActive (false);
		}

		public void OnClickOkRulesAbouButton ()
		{
			
			gridMain.SetActive (true);
			backgroundGrid.SetActive (true);
			mainMenuPanel.SetActive (true);

			rulesPanel.SetActive (false);
			aboutPanel.SetActive (false);

		}
		#endregion
		///////////////////////////////////////////////////////////////////////////
	}
}
