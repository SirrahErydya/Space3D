﻿using UnityEngine;
using System.Collections;

public class Decrease : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			UfoMovement.Life = UfoMovement.Life -1;
		}
		
	}
}
