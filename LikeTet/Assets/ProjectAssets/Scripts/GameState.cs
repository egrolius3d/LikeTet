using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LikeTet
{
	public class GameState  : AppState {


		GameObject fallingShape;
		GameObject nextShape;
		public string[] basicShapesPath = new string[7]
		{
			"Models/ShapeI",
			"Models/ShapeJ",
			"Models/ShapeL ",
			"Models/ShapeO",
			"Models/ShapeS",
			"Models/ShapeT",
			"Models/ShapeZ"
		};




		public   override void Activate (IStateData data, bool reset)
		{
			mId = EAppStateId.Game;

			Debug.Log ("Activate from Game State");
			Debug.Log ("This is game Mid = "+mId);
			Debug.Log ("This is base Mid = "+base.mId);
			//GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range (0, 5)]));

			fallingShape=  GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range(0,7)]),new Vector3(5,21,0),Quaternion.identity ) as GameObject;

			nextShape = GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range(0,7)]),new Vector3(15,15,0), Quaternion.identity) as GameObject;
			nextShape.GetComponent<Figure>().enabled = false;

		}
		public   override void Deactivate ()
		{
			DestroyAllGameObjects ();
			fallingShape = null;
			Debug.Log ("deactivate from gameState");
		}
		public  override void Initialize () //state start
		{
			Debug.Log ("Initialize  game state");
		}

		public override void Update ()
		{

			if (!fallingShape.GetComponent<Figure> ().enabled) {
				if (fallingShape.GetComponent<Figure> ().IsAboveGridCheck ()) {
					Debug.Log ("Game Over 111111111111111111111111111");
					AppRoot.Instance.SetState (EAppStateId.MainMenu);
				}
				if (fallingShape != null) {
					fallingShape = nextShape;
					fallingShape.transform.position = new Vector3 (5, 21, 0);
					fallingShape.GetComponent<Figure> ().enabled = true;
					SpawnNewNextFigure ();
				}

			}
			if (Input.GetKeyDown (KeyCode.Q)) 
			{
				DestroyAllGameObjects ();

				AppRoot.Instance.SetState (EAppStateId.MainMenu);
			}



			//Debug.Log ("Update from GameState");

		}
		public override void OnGUI()
		{
			// Debug.Log("OnGUI");
		}
		public  override void OnUiAction(GameObject pressedGo, object p)
		{
			 // Debug.Log("OnUiAction");
		}
		public   void SpawnNewNextFigure()
		{
			nextShape = GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range(0,7)]),new Vector3(15,15,0), Quaternion.identity) as GameObject;
			nextShape.GetComponent<Figure>().enabled = false;
		}



}

}