using UnityEngine;
using System.Collections;

public class Enemy : Movable {

	public Transform target;
	
	// The distance in the x-z plane to the target
	public int distance = 10;
	// the height we want the camera to be above the target
	public int height = 10;
	// How much we 
	public float heightDamping = 2.0F;
	public float rotationDamping = 0.6F;

	float timer;

	// Use this for initialization
	void Start () {
		velocity = START_VELOCITY;

	}
	
	// Update is called once per frame
	void Update () {

		if (viewUfo ()) {
			
			timer = timer + Time.deltaTime;
			if (timer % 2 < 0.1) {
				shoot ();
			}
		}
		move ();
	}


	void shoot() {
		if (shooter != null) {
			Vector3 position = new Vector3 (0, 0, 0);
			shoot (position, shooter.transform.rotation);
		}
	}
	

	bool viewUfo() {
		GameObject ufo = GameObject.FindGameObjectWithTag ("Player");
		if (ufo == null) {
			Debug.Log ("Error: No Player Object");
			return false;
		}
		float xDiff = transform.position.x - ufo.transform.position.x;
		float yDiff = transform.position.y - ufo.transform.position.y;
		float zDiff = transform.position.z - ufo.transform.position.z;

		if (xDiff < 1 && yDiff < 1 && zDiff < 1) {
			return true;
		}
		return false;
	}

	void move() {
		Vector3 z = new Vector3 (0F, 0F, -0.1F);
		transform.position = Vector3.Lerp (transform.position, transform.position + z, Time.deltaTime * smooth);
	}

	void followTarget() {
		if (!target)
			return;
			
		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;
			
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;
			
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
			
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
			
		// Convert the angle into a rotation
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
			
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
			
		// Set the height of the camera
		transform.position = transform.position + new Vector3(0, currentHeight, 0);
			
		// Always look at the target
		transform.LookAt (target);
	}
	
	


}
