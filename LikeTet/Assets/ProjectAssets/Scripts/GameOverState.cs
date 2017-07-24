using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LikeTet
{
	public class GameOverState : AppState {
		///////////////////////////////////////////////////////////////////////////
		#region Variables
		GameObject view;
		ViewScript viewScript;
		GameObject gameOverButton;
		GameObject gameOverPanel;

		#endregion
		///////////////////////////////////////////////////////////////////////////

		///////////////////////////////////////////////////////////////////////////
		#region Implementation
		public  override void Initialize() 
		{

			view = GameObject.Find ("View");
			viewScript=view.GetComponent <ViewScript>();

			//viewScript.gameOverPanel = GameObject.Find ("GameOverPanel");
			//viewScript.okGameOverButton = GameObject.Find ("OkGameOverButton");

			viewScript.okGameOverButton.GetComponent<Button>().onClick.AddListener (OnClickGameOverButton);
			viewScript.gameOverPanel.SetActive (false);
			viewScript.okGameOverButton.SetActive (false);


			Debug.Log ("Inialize GameOverState");
		}

		public override void Activate (IStateData data, bool reset)
		{
			mId = EAppStateId.GameOver;
			viewScript.gameOverPanel.SetActive (true);
			viewScript.okGameOverButton.SetActive (true);

			Debug.Log ("Activate GameOverState");

		}


	
		public   override void Deactivate ()
		{
			
			viewScript.gameOverPanel.SetActive (false);
			viewScript.okGameOverButton.SetActive (false);
			Debug.Log ("Diactivate GameOverState");


		}
		// Update is called once per frame
		public override void Update () {
			
		
		}

		public void OnClickGameOverButton (){
			
			AppRoot.Instance.SetState (EAppStateId.MainMenu);
		}
		#endregion
		///////////////////////////////////////////////////////////////////////////
	}	
}
