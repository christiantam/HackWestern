using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {
	
	private int _attack{
		get;
		set;
	}
	private int _armor;
	private int _move;
	private int _attackrange;
	
	public int Attack {
		get;
		set;
	}
	
	public int Armor {
		get;
		set;
	}
	
	public int Move {
		get;
		set;
	}
	
	public int Attackrange {
		get;
		set;
	}
}
