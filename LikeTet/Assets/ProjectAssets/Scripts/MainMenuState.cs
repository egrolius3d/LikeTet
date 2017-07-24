using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LikeTet
{
	public class MainMenuState : AppState {
		///////////////////////////////////////////////////////////////////////////
		#region Variables
		GameObject view;
		ViewScript viewScript;

		/*GameObject gameButton;
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
		*/
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
			view = GameObject.Find ("View");
			viewScript=view.GetComponent <ViewScript>();
			/*
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
			backgroundGrid = GameObject.Find ("BackgroundGrid");*/
	

			viewScript.gameButton.GetComponent<Button>().onClick.AddListener (OnClickGameButton);
			viewScript.exitButton.GetComponent<Button>().onClick.AddListener (OnClickExitButton);
			viewScript.newGameButton.GetComponent<Button>().onClick.AddListener (OnClickNewGameButton);

			viewScript.helpButton.GetComponent<Button>().onClick.AddListener (OnClickHelpButton);
			viewScript.rulesButton.GetComponent<Button>().onClick.AddListener (OnClickRulesButton);
			viewScript.aboutButton.GetComponent<Button>().onClick.AddListener (OnClickAboutButton);

			viewScript.okRulesButton.GetComponent<Button> ().onClick.AddListener (OnClickOkRulesAbouButton);
			viewScript.okAboutButton.GetComponent<Button> ().onClick.AddListener (OnClickOkRulesAbouButton);

			viewScript.aboutPanel.SetActive (false);
			viewScript.rulesPanel.SetActive (false);

			viewScript.newGameButton.SetActive (false);
			viewScript.exitButton.SetActive (false);
			viewScript.rulesButton.SetActive (false);
			viewScript.aboutButton.SetActive (false);

			viewScript.gridMain.SetActive (true);
			viewScript.backgroundGrid.SetActive (true);
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
			viewScript.newGameButton.SetActive (true);
			viewScript.exitButton.SetActive (true);
			viewScript.aboutButton.SetActive (false);
			viewScript.rulesButton.SetActive (false);
		}

		public void OnClickNewGameButton()
		{
			viewScript.newGameButton.SetActive (false);
			viewScript.exitButton.SetActive (false);

			AppRoot.Instance.SetState (EAppStateId.Game);

			Debug.Log ("Pressed Game Button");
		}

		public void OnClickExitButton()
		{
			viewScript.newGameButton.SetActive (false);
			viewScript.exitButton.SetActive (false);
			Application.Quit();
		}

		public void OnClickHelpButton()
		{
			AppRoot.Instance.SetState (EAppStateId.MainMenu);
			viewScript.newGameButton.SetActive (false);
			viewScript.exitButton.SetActive (false);
			viewScript.rulesButton.SetActive (true);
			viewScript.aboutButton.SetActive (true);
		}

		public void OnClickRulesButton()
		{
			viewScript.gridMain.SetActive (false);
			viewScript.backgroundGrid.SetActive (false);
			viewScript.mainMenuPanel.SetActive (false);

			viewScript.rulesPanel.SetActive (true);
			viewScript.rulesButton.SetActive (false);
			viewScript.aboutButton.SetActive (false);
		}

		public void OnClickAboutButton()
		{
			viewScript.gridMain.SetActive (false);
			viewScript.backgroundGrid.SetActive (false);
			viewScript.mainMenuPanel.SetActive (false);
			viewScript.aboutPanel.SetActive (true);
			viewScript.rulesButton.SetActive (false);
			viewScript.aboutButton.SetActive (false);
		}

		public void OnClickOkRulesAbouButton ()
		{
			
			viewScript.gridMain.SetActive (true);
			viewScript.backgroundGrid.SetActive (true);
			viewScript.mainMenuPanel.SetActive (true);

			viewScript.rulesPanel.SetActive (false);
			viewScript.aboutPanel.SetActive (false);

		}
		#endregion
		///////////////////////////////////////////////////////////////////////////
	}
}
