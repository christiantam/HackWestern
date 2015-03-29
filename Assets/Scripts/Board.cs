using UnityEngine;
using System.Collections;

public abstract class Board : MonoBehaviour {

	private int _size;
	private GameObject[][] _board;

	public int Size {
		get;
		set;
	}

	public GameObject[][] GameBoard {
		get;
		set;
	}

	public GameObject Content {
		get;
		set;
	}
}
