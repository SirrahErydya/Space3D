using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public float speed;
	public Transform target;
	public float smooth;

	private Vector3 zIncrease;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();



	}
	
	// Update is called once per frame
	void Update () {
		/*
		zIncrease = new Vector3 (0, 0, speed);
		transform.Translate (zIncrease);*/
		if (UfoMovement.Velocity != 0) {
			rb.velocity = transform.up * (speed * UfoMovement.Velocity);
		} else {
			rb.velocity = transform.up * (speed);
		}


	}


	

}
