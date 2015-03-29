using UnityEngine;
using System.Collections;

public abstract class TerrainType : MonoBehaviour {

	private int _armor;
	private string _type;

	public string Type {
		get;
		set;
	}

	public int Armor {
		get;
		set;
	}
}