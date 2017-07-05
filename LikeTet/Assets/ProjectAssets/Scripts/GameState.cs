using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LikeTet
{
	public class GameState  : AppState {
		public int oneLineScore = 1;
		public int twoLineScore = 2;
		public int threeLineScore = 3;
		public int fourLineScore = 4;

		private static int scoreCount=0;
		private static int totalLinesCount=0;
		private static int oneTurnLinesCount=0;
		private static int levelCount=1;
		public static int currentLevel=1;

		public static int gridWeight = 10;
		public static int gridHeight = 24;
		public static Transform[,] grid = new Transform [gridWeight,gridHeight];

		public static int fallSpeed=2;
		public float hightFallSpeed = 3;
		float fall=0;
		public int howManyRows = 0;


		GameObject totalLinesText;
		GameObject scoreText;
		GameObject levelText;

		GameObject fallingShape;
		GameObject nextShape;
		GameObject lastShape;


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
			ResetScore ();
			mId = EAppStateId.Game;
			SetScoreText ();
			Debug.Log ("Activate from Game State");
			Debug.Log ("This is game Mid = "+mId);
			Debug.Log ("This is base Mid = "+base.mId);

			fallingShape=  GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range(0,7)]),new Vector3(5,21,0),Quaternion.identity ) as GameObject;

			nextShape = GameObject.Instantiate (Resources.Load (basicShapesPath [Random.Range(0,7)]),new Vector3(15,15,0), Quaternion.identity) as GameObject;
			AppRoot.Instance.StartCoroutine (MoveDownCoroutine());


		}
		public   override void Deactivate ()
		{
			ResetScore ();
			DestroyAllGameObjects ("basicShape");
			GameObject.Destroy (nextShape);
			GameObject.Destroy (fallingShape);
			GameObject.Destroy (lastShape);
			Debug.Log ("deactivate from gameState");
		}
		public  override void Initialize () //state start
		{
			Debug.Log ("Initialize  game state");
		}
			
		/////////////////////////////////////////////////////////////////////
	
		public override void Update ()
		{
			//AppRoot.Instance.StartCoroutine (CheckUserInputCoroutine());

			//UpdateScore ();
			this.UpdateUI ();
			//UpdateLevel ();
			UpdateFallSpeed();
			CheckUserInput ();


			if (fallingShape== null) {

				fallingShape = nextShape;
				fallingShape.transform.position = new Vector3 (5, 21, 0);
				SpawnNewNextFigure ();
				if (IsAboveGridCheck ()) {
					Debug.Log ("Game Over");
					AppRoot.Instance.SetState (EAppStateId.GameOver);
				}
					

			}

			if (Input.GetKeyDown (KeyCode.Q)) 
			{
				DestroyAllGameObjects ("basicShape");

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
		}


		public  bool IsAboveGridCheck ()
		{
			for (int x = 0; x < gridWeight; ++x) 
			{
				foreach (Transform child in lastShape.transform) 
				{
					Vector3 pos = round (child.position);
					if (pos.y >= 20)
						return true;


				}
			}
			return false;
		}

			void CheckUserInput()
		{
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				fallingShape.transform.position += new Vector3 (-1,0,0);
				if (isValidPosition ())
					GridUpdate ();
				else
					fallingShape.transform.position += new Vector3 (1, 0, 0);

			} 

			else if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
				fallingShape.transform.position += new Vector3 (1,0,0);
				if (isValidPosition ())
					GridUpdate ();
				else
					fallingShape.transform.position += new Vector3 (-1, 0, 0);
			}
			////////////////////////////////////////////////////////////////////
			else if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				while (isValidPosition ())
				{
					fallingShape.transform.position += new Vector3 (0, -1, 0);
					if (!isValidPosition ()) {
						fallingShape.transform.position += new Vector3 (0, 1, 0);
						break;
					}
					//	for (int y = 0; y < gridHeight; ++y) 
					//	{
					//		if (IsRowFull (y)) 
					//		{
					//			yield return AppRoot.Instance.StartCoroutine (DestroyerCoroutine (y));
					//			//AppRoot.Instance.StartCoroutine (DestroyerCoroutine(y));

					//			Debug.Log ("After cocoutine");
					//			for (int x = 0; x < gridWeight; ++x) {
					//				Object.Destroy (grid [x, y].gameObject);
					//				grid [x, y] = null;
					//			}
								//Delete (y);
								//while (IsRowFull (y)) {
								//}
								//Delete (y);

						//		MoveRowDownAll (y + 1);
						//		--y;

						//	}

						//}
						//break;
					//}

					GridUpdate (); 
				}

				//fallingShape.transform.position += new Vector3 (0,1,0);

				//DeleteRow ();
				//for (int y = 0; y < gridHeight; ++y) 
			//	{
				//	if (IsRowFull (y)) 
				//	{
				//		yield return AppRoot.Instance.StartCoroutine (DestroyerCoroutine (y));
						//AppRoot.Instance.StartCoroutine (DestroyerCoroutine(y));

				//		Debug.Log ("After cocoutine");
				//		for (int x = 0; x < gridWeight; ++x) {
				//			Object.Destroy (grid [x, y].gameObject);
				//			grid [x, y] = null;
				//		}
						//Delete (y);
						//while (IsRowFull (y)) {
						//}
						//Delete (y);

				//		MoveRowDownAll (y + 1);
				//		--y;

				//	}

				//}


				//DeleteRow ();
				//lastShape = fallingShape;


				//fallingShape = null;



			}
			////////////////////////////////////////////////////////////////////////



			////////////////////////////////////////////////////////////////////////
			else if (Input.GetKeyDown (KeyCode.Space)) 
			{
				fallingShape.transform.Rotate (0,0,90);
				if (isValidPosition ()) {
					GridUpdate ();
				} else
					fallingShape.transform.Rotate (0, 0, -90);
			}
		}

		bool isValidPosition () {
			foreach (Transform child in fallingShape.transform) 
			{
				Vector3 curVector= round (child.position);
				if (!isInsideGrid (curVector))
					return false;
				if (grid [(int)curVector.x, (int)curVector.y] != null &&
					grid [(int)curVector.x, (int)curVector.y].parent != fallingShape.transform)
					return false;
			}
			return true;
		}
		public  Vector3 round (Vector3 curVector){
			return new Vector3 (Mathf.Round (curVector.x), Mathf.Round (curVector.y), 0);
		}
		public  bool isInsideGrid  (Vector3 pos){
			return ((int)pos.x>= 0 && (int)pos.x< gridWeight && (int)pos.y>=0);
		}

		void GridUpdate (){
			for (int y = 0; y < gridHeight; ++y) 
			{
				//Debug.Log (y);
				for (int x = 0; x < gridWeight; ++x) 
				{
					//Debug.Log (x);
					if (grid [x, y] != null) 
					{
						if (grid [x, y].parent == fallingShape.transform)
							grid [x, y] = null;
					}
				}
			}
			foreach (Transform child in fallingShape.transform) 
			{
				Vector3 curV = round (child.position);
				grid [(int)curV.x, (int)curV.y] = child;
			}

		}
		public  bool IsRowFull (int y)
		{
			for (int x = 0; x < gridWeight; ++x)
				if (grid [x, y] == null)
					return false;
			/////////////////////////////////////////////
			//oneTurnLinesCount++;
			return true;
		}
		/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public  void Delete (int y)
		{
			//yield return AppRoot.Instance.StartCoroutine (DestroyerCoroutine(y));

			//	for (int x = 0; x < gridWeight; ++x) {
			//		Object.Destroy (grid [x, y].gameObject);
			//		grid [x, y] = null;
			//	}

		}

		public  void DeleteRow()
		{
			for (int y = 0; y < gridHeight; ++y) 
			{
				if (IsRowFull (y)) 
				{
					Debug.Log ("Before cocoutine!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
					//AppRoot.Instance.StartCoroutine (DestroyerCoroutine(y));

					Debug.Log ("After cocoutine");
					//Delete (y);
					//while (IsRowFull (y)) {
					//}
					//Delete (y);

					MoveRowDownAll (y + 1);
					--y;

				}

			}

		}

		public  void MoveRowDown (int y) 
		{
			for (int x = 0; x < gridWeight; ++x) 
			{
				if (grid [x, y] != null) 
				{
					grid [x, y - 1] = grid [x, y];
					grid [x, y] = null;
					grid [x, y - 1].position += new Vector3 (0,-1,0);
				}
			}
		}

		public  void MoveRowDownAll (int y)
		{
			for (int i = y; i < gridHeight; ++i)
				MoveRowDown (i);
		}
		public  void DestroyAllGameObjects (string tag)
		{
			GameObject[] shapes = GameObject.FindGameObjectsWithTag (tag);
				foreach (GameObject shape in shapes)
				Object.Destroy (shape);
		}

		public  void UpdateScore()
		{
			if (oneTurnLinesCount > 0) {
				if (oneTurnLinesCount == 1) {
				//1 point	
					SetLineScore (1);
				}
				if (oneTurnLinesCount == 2) {
				//3 points
					SetLineScore (3);
				}
				if (oneTurnLinesCount == 3) {
				//5 points
					SetLineScore (5);
				}
				if (oneTurnLinesCount == 4) {
				//8 points
					SetLineScore (8);
				}
				totalLinesCount += oneTurnLinesCount;
				if (totalLinesCount % 5 == 0) {
					levelCount++;
				}
				oneTurnLinesCount = 0;
			}
		}


		public  void  SetLineScore (int points)
		{
			scoreCount += points;
		}



		public  void SetScoreText()
		{
			scoreText= GameObject.Find ("scoreText");

			totalLinesText = GameObject.Find ("lineCountText");

			levelText= GameObject.Find ("levelText");
		}

		public  void UpdateUI()
		{
			scoreText.GetComponent<Text>().text = scoreCount.ToString ();
			totalLinesText.GetComponent<Text>().text= totalLinesCount.ToString ();
			levelText.GetComponent<Text>().text = levelCount.ToString ();
		}
		public  void ResetScore ()
		{
			scoreCount=0;
			totalLinesCount=0;
			oneTurnLinesCount=0;
			levelCount=1;
		}
		public  void UpdateLevel()
		{
			levelCount = 1;
			Debug.Log (levelCount + " Level count");

		}
		public  void UpdateFallSpeed()
		{
			//fallSpeed= 1.0f- (float)levelCount*0.1f;
			fallSpeed= levelCount;
		}

		 IEnumerator VanishingCoroutine (int y){



			for (float f = 1f; f >= 0; f -= 0.2f) {
				for (int x = 0; x < gridWeight; ++x) {
					if (grid [x, y] != null) {
						Renderer objRenderer;
						objRenderer = grid [x, y].GetComponent<Renderer> ();

						Color c = grid [x, y].GetComponent<Renderer> ().material.color;
						c.a = f;
						Debug.Log (c.a);
						Debug.Log (grid [x, y].GetComponent<Renderer> ());

						objRenderer.material.color = c;
						Debug.Log (grid [x, y].GetComponent<Renderer> ().material.color.a + " Color alpha");
					}
				}
				yield return new WaitForSeconds (0.0001f);
			}


		}

		 IEnumerator DestroyerCoroutine (int y){
			yield return AppRoot.Instance.StartCoroutine (VanishingCoroutine(y));
			//Debug.Log ("After Vanishing");
			//for (int x = 0; x < gridWeight; ++x) {
			//	Object.Destroy (grid [x, y].gameObject);
			//	grid [x, y] = null;
			//}
			yield return null;
		}

		IEnumerator MoveDownCoroutine () {
			yield return new WaitForSeconds (1f/levelCount); //1f/(fallSpeed+1)
			Debug.Log (fallSpeed);

			fallingShape.transform.position += new Vector3 (0,-1,0);
			if (isValidPosition ()) {
				GridUpdate ();
			} else {
					fallingShape.transform.position += new Vector3 (0,1,0);

					for (int y = 0; y < gridHeight; ++y) 
					{
						if (IsRowFull (y)) 
						{
							oneTurnLinesCount++;

							Debug.Log ("Eror11111111111111111111111111");
							yield return AppRoot.Instance.StartCoroutine (DestroyerCoroutine (y));
							//AppRoot.Instance.StartCoroutine (DestroyerCoroutine(y));

							Debug.Log ("After cocoutine");
							for (int x = 0; x < gridWeight; ++x) {
								Object.Destroy (grid [x, y].gameObject);
								grid [x, y] = null;
							}
							//Delete (y);
							//while (IsRowFull (y)) {
							//}
							//Delete (y);

							MoveRowDownAll (y + 1);
							--y;

						}
						
					}
					UpdateScore ();
					//UpdateLevel ();
					//UpdateFallSpeed ();

					//DeleteRow ();
					lastShape = fallingShape;


					fallingShape=null;


				}
			fall = Time.time;
			AppRoot.Instance.StartCoroutine (MoveDownCoroutine());
		}
	}

}