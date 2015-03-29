using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]

public abstract class Unit : MonoBehaviour {
	
	public int Attack { get; set;}
	public int Armor { get; set;}
	public int MoveRange { get; set;}
	public int MovesLeft { get; set;}
	public int AttackRange { get; set;}
	public int RangeLeft { get; set;}
	private float speed;
	private Vector3 pos;
	private Vector3 attackTarget;
	private Vector3 origin;
	private Transform tr;
	private bool selected;
	private bool attackPhase;
	private bool movePhase;

	void Start() {
		speed = 7.0F;
		pos = transform.position;
		origin = transform.position;
		attackTarget = transform.position;
		tr = transform;
		MovesLeft = MoveRange;
		attackPhase = false;
		movePhase = false;
		selected = false;
	}

	void Update() {
		//If nothing is selected, select this unit and enter its movement phase.
		if(Input.GetMouseButtonUp (0) && !selected) {
			bool someOtherUnitSelected = false;
			Unit[] units = FindObjectsOfType<Unit>();
			foreach(Unit unit in units) {
				if(unit.isSelected ()) {
					someOtherUnitSelected = true;
				}
			}
			if(!someOtherUnitSelected) {
				selected = true;
				movePhase = true;
			}
		}

		//If this unit is in its movement phase and has moves left, allow it to move.
		if(selected && MovesLeft > 0 && movePhase) {
			if(Input.GetKeyDown (KeyCode.W) && tr.position == pos) {
				pos += Vector3.up;
				MovesLeft--;
			}
			else if(Input.GetKeyDown (KeyCode.A) && tr.position == pos) {
				pos += Vector3.left;
				MovesLeft--;
			}
			else if(Input.GetKeyDown (KeyCode.S) && tr.position == pos) {
				pos += Vector3.down;
				MovesLeft--;
			}
			else if(Input.GetKeyDown (KeyCode.D) && tr.position == pos) {
				pos += Vector3.right;
				MovesLeft--;
			}
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
		}

		//If escape key is pressed:
		if(Input.GetKeyDown (KeyCode.Escape) ){
			//Reset attack phase if range was expended.
			if(RangeLeft < AttackRange) {
				RangeLeft = AttackRange;
				attackTarget = pos;
			}
			//If in attack phase with full attack range, exit attack phase and restart movement phase from beginning.
			else if(attackPhase) {
				attackPhase = false;
				movePhase = true;
				MovesLeft = MoveRange;
				transform.position = origin;
			}
			//If still in movement phase with moves expended, restart movement phase from beginning.
			else if(MovesLeft < MoveRange) {
				MovesLeft = MoveRange;
				transform.position = origin;
			}
			//Otherwise, deselect the unit.
			else if(isSelected()) {
				selected = false;
				movePhase = false;
			}
		}

		//If enter is pressed:
		if(Input.GetKeyDown (KeyCode.Return) ) {
			//During movement phase, end the movement phase and start attack phase.
			if(movePhase) {
				movePhase = false;
				attackPhase = true;
			}
			//During attack phase, confirm attack if the target exists and is not an ally
			else if(attackPhase /*&& enemy target exists*/) {
				//Attack target in space
				attackPhase = false;
				selected = false;
			}
		}

		//During attack phase, if there is any attack range remaining, allow unit to aim attack.
		if(selected && RangeLeft > 0 && attackPhase) {
			if(Input.GetKeyDown (KeyCode.W) && tr.position == attackTarget) {
				attackTarget += Vector3.up;
				RangeLeft--;
			}
			else if(Input.GetKeyDown (KeyCode.A) && tr.position == attackTarget) {
				attackTarget += Vector3.left;
				RangeLeft--;
			}
			else if(Input.GetKeyDown (KeyCode.S) && tr.position == attackTarget) {
				attackTarget += Vector3.down;
				RangeLeft--;
			}
			else if(Input.GetKeyDown (KeyCode.D) && tr.position == attackTarget) {
				attackTarget += Vector3.right;
				RangeLeft--;
			}
		}
	}

	public bool isSelected() {
		return selected;
	}

	public void select() {
		selected = true;
	}

	public void deselect() {
		selected = false;
	}

	public void die() {
		//Play death animation
		Object.Destroy(this);
	}
}
