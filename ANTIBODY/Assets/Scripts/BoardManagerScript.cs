using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerScript : MonoBehaviour {

	//Constants defined
	public static int row = 27, col = 9;
	int[,] board = new int[row, col];

	/*
	 * Splits our board pieces into the usable (i.e. center),
	 * and the unusable (i.e. edges)
	*/
	public GameObject usableBoardPiece;
	public GameObject unusableBoardPiece;

	//Holds our game objects to prevent clutter in the hierarchy
	Transform parentBoard;

	void Start () {
		LayoutBoard (usableBoardPiece, unusableBoardPiece);
	}

	void LayoutBoard(GameObject thisInnerPiece, GameObject thisOuterPiece)
	{
		parentBoard = new GameObject ("BoardHolder").transform;
		parentBoard.SetParent (this.transform);

		//Our current object we're setting
		GameObject thisObject;

		//2D Board Array
		for (int x = 0; x < row; x++) 
		{
			for (int y = 0; y < col; y++) 
			{
				//Checks for an edge on our grid, and places an unusable block there
				if ( x == 0 || x == (row-1) || y == 0 || y == (col-1) )
				{
					thisObject = Instantiate (thisOuterPiece, new Vector3 (x, y, 0f), Quaternion.identity);
					thisObject.transform.SetParent (parentBoard);
				} 
				else 
				{
					thisObject = Instantiate (thisInnerPiece, new Vector3 (x, y, 0f), Quaternion.identity);
					thisObject.transform.SetParent (parentBoard);
				}
			}
		}
	}

}
