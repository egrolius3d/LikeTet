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
			
			Debug.Log ("Activate from Game State");
			//GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range (0, 5)]));

			fallingShape=  GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range(0,6)]),new Vector3(5,19,0),Quaternion.identity ) as GameObject;

			nextShape = GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range(0,6)]),new Vector3(15,15,0), Quaternion.identity) as GameObject;
			nextShape.GetComponent<Figure>().enabled = false;

		}
		public   override void Deactivate ()
		{
			Debug.Log("000000000000000000000000000000000000000000000000000000000");
			while (GameObject.FindWithTag("basicShape")!=null)
			Object.Destroy (GameObject.FindWithTag("basicShape"));

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
					this.Deactivate ();
					AppRoot.Instance.SetState (EAppStateId.MainMenu, true);
				}
				fallingShape = nextShape;
				fallingShape.transform.position = new Vector3 (5, 19, 0);
				fallingShape.GetComponent<Figure> ().enabled = true;

				SpawnNewNextFigure ();
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
			nextShape = GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range(0,6)]),new Vector3(15,15,0), Quaternion.identity) as GameObject;
			nextShape.GetComponent<Figure>().enabled = false;
		}

}

}