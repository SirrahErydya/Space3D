using UnityEngine;
using System.Collections;

public class Enemy : Movable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//shoot ();
	}


	void shoot() {
		Quaternion rotation = new Quaternion ();
		rotation.Set (2F, 0F, 0F, 1F);
		Vector3 position = new Vector3 (0, 0, 0);
		shoot (position, rotation);
	}


}
