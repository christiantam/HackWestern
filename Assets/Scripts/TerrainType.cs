using UnityEngine;
using System.Collections;

abstract class Terrain : MonoBehaviour {

	private int armor;
	private string type;

	public abstract string getType{
		get;
	}

}
