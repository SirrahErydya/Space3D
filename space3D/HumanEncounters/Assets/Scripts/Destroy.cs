﻿using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public string tag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag (tag) || other.CompareTag("Finish")) {
			Destroy(other.gameObject);
			Destroy (gameObject);
			Debug.Log (other);
		}

	}

}
