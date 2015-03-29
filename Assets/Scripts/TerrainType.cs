using UnityEngine;
using System.Collections;

abstract class Terrain : MonoBehaviour {

	private int _armor;
	private string _type;

	public abstract string Type{
		get;
	}

	public abstract int Armor{
		get;
	}
}
