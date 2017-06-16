using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour {

	public  static int gridWeight = 10;
	public static int gridHeight = 22;
	public static Transform[,] grid = new Transform [gridWeight,gridHeight];

	public float fallSpeed=1;
	public float hightFallSpeed = 3;
	float fall=0;
	public int howManyRows = 0;

	void Update () {
		CheckUserInput ();
	}
	public  bool IsAboveGridCheck ()
	{
		for (int x = 0; x < gridWeight; ++x) 
		{
			foreach (Transform child in this.transform) 
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
			this.transform.position += new Vector3 (-1,0,0);
			if (isValisPosition ())
				GridUpdate ();
			else
				transform.position += new Vector3 (1, 0, 0);

		} 

		else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			this.transform.position += new Vector3 (1,0,0);
			if (isValisPosition ())
				GridUpdate ();
			else
				transform.position += new Vector3 (-1, 0, 0);
		}
		////////////////////////////////////////////////////////////////////
		else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			while (isValisPosition ())
			{
				this.transform.position += new Vector3 (0, -1, 0);
				if (!isValisPosition ()) 
				{
					break;
				}
					
				GridUpdate (); 
			}

				this.transform.position += new Vector3 (0,1,0);
				DeleteRow ();
				this.enabled = false;



		}
		////////////////////////////////////////////////////////////////////////
		else if (Time.time-fall>=fallSpeed) 
		{
			this.transform.position += new Vector3 (0,-1,0);
			if (isValisPosition ()) {
				GridUpdate ();
			} else {
				this.transform.position += new Vector3 (0,1,0);
				DeleteRow ();
				this.enabled = false;

			}
			fall = Time.time;
		}


		////////////////////////////////////////////////////////////////////////
		else if (Input.GetKeyDown (KeyCode.Space)) 
		{
			this.transform.Rotate (0,0,90);
			if (isValisPosition ()) {
				GridUpdate ();
			} else
				this.transform.Rotate (0, 0, -90);
		}
	}

	bool isValisPosition () 
	{
		foreach (Transform child in this.transform) 
		{
			Vector3 curVector= round (child.position);
			if (!isInsideGrid (curVector))
				return false;
			if (grid [(int)curVector.x, (int)curVector.y] != null &&
			    grid [(int)curVector.x, (int)curVector.y].parent != transform)
				return false;
		}
		return true;
	}
	public static Vector3 round (Vector3 curVector)
	{
		return new Vector3 (Mathf.Round (curVector.x), Mathf.Round (curVector.y), 0);
	}
	public static bool isInsideGrid  (Vector3 pos)
	{
		return ((int)pos.x>= 0 && (int)pos.x< gridWeight && (int)pos.y>=0);
	}

	void GridUpdate ()
	{
		for (int y = 0; y < gridHeight; ++y) 
		{
			//Debug.Log (y);
			for (int x = 0; x < gridWeight; ++x) 
			{
				//Debug.Log (x);
				if (grid [x, y] != null) 
				{
					if (grid [x, y].parent == this.transform)
						grid [x, y] = null;
				}
			}
		}
		foreach (Transform child in this.transform) 
		{
			Vector3 curV = round (child.position);
			grid [(int)curV.x, (int)curV.y] = child;
		}
		
	}
	public static bool IsRowFull (int y)
	{
		for (int x = 0; x < gridWeight; ++x)
			if (grid [x, y] == null)
				return false;
		//plase number of rows
		return true;
	}

	public static void Delete (int y)
	{
		for (int x = 0; x < gridWeight; ++x) 
		{
			Destroy (grid [x, y].gameObject);
			grid [x, y] = null;
		}
	}

	public static void DeleteRow()
	{
		for (int y = 0; y < gridHeight; ++y) 
		{
			if (IsRowFull (y)) 
			{
				Delete (y);
				MoveRowDownAll (y + 1);
				--y;

			}
		}

	}

	public static void MoveRowDown (int y) 
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

	public static void MoveRowDownAll (int y)
	{
		for (int i = y; i < gridHeight; ++i)
			MoveRowDown (i);
	}


}
