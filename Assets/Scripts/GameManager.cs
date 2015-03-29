using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//private UnitBoard p1Units;
	//private UnitBoard p2Units;
	//private TerrainBoard map;
	private bool player1Turn;
	private float movespeed;
	private Vector3 position;
	private Transform tr;

	//private int startingUnits;

	// Use this for initialization
	void Start () {
		player1Turn = true; //randomize?
		movespeed = 7.0F;
		position = transform.position;
		tr = transform;
		//startingUnits = 6;
	}

	/* Hard code starting units for now
	public void Draft() {
		for(int i = 0; i < startingUnits; i++) {

		}
	}
	*/

	public void Move () {



		
		transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * movespeed);
	}

	// Update is called once per frame
	void Update () {


	}
}
