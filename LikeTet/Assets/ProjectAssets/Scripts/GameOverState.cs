using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LikeTet
{
	public class GameOverState : AppState {
		///////////////////////////////////////////////////////////////////////////
		#region Variables

		GameObject gameOverButton;
		GameObject gameOverPanel;

		#endregion
		///////////////////////////////////////////////////////////////////////////

		///////////////////////////////////////////////////////////////////////////
		#region Implementation
		public  override void Initialize() 
		{



			gameOverPanel = GameObject.Find ("GameOverPanel");
			gameOverButton = GameObject.Find ("OkGameOverButton");

			gameOverButton.GetComponent<Button>().onClick.AddListener (OnClickGameOverButton);
			gameOverPanel.SetActive (false);
			gameOverButton.SetActive (false);


			Debug.Log ("Inialize GameOverState");
		}

		public override void Activate (IStateData data, bool reset)
		{
			mId = EAppStateId.GameOver;
			gameOverPanel.SetActive (true);
			gameOverButton.SetActive (true);

			Debug.Log ("Activate GameOverState");

		}


	
		public   override void Deactivate ()
		{
			
			gameOverPanel.SetActive (false);
			gameOverButton.SetActive (false);
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
