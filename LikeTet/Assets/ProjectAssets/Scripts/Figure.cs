using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour {

	public  static int gridWeight = 10;
	public static int gridHeight = 22;
	public static Transform[,] grid = new Transform [gridWeight,gridHeight];

	public float fallSpeed=1;
	float fall=0;
		
	// Update is called once per frame
	void Update () {
		CheckUserInput ();
	}

	void CheckUserInput()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.transform.position += new Vector3 (-1,0,0);
			if (isValisPosition ())
				gridUpdate ();
			else
				transform.position += new Vector3 (1, 0, 0);

		} 

		else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			this.transform.position += new Vector3 (1,0,0);
			if (isValisPosition ())
				gridUpdate ();
			else
				transform.position += new Vector3 (-1, 0, 0);
		}

		else if (Input.GetKeyDown (KeyCode.DownArrow)|| Time.time-fall>=fallSpeed) 
		{
			this.transform.position += new Vector3 (0,-1,0);
			if (isValisPosition ()) {
				gridUpdate ();
			} else {
				this.transform.position += new Vector3 (0,1,0);
				this.enabled = false;

			}
			fall = Time.time;
		}
		else if (Input.GetKeyDown (KeyCode.Space)) 
		{
			this.transform.Rotate (0,0,90);
			if (isValisPosition ()) {
				gridUpdate ();
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

	void gridUpdate ()
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
}
