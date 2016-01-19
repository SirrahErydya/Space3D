using UnityEngine;
using System.Collections;

public class UfoMovement : Movable {

	public float trans;
	private Vector3 xTrans;
	private Vector3 yTrans;
	private Vector3 zTrans;

	//Input bools
	bool w;
	bool s;
	bool up;
	bool down;
	bool left;
	bool right;
	

	// Use this for initialization
	void Start () {
		velocity = START_VELOCITY;

		xTrans = new Vector3 (trans, 0, 0);
		yTrans = new Vector3 (0, trans, 0);


	}
	
	// Update is called once per frame
	void Update () {

		w = Input.GetKey (KeyCode.W);
		s = Input.GetKey (KeyCode.S);
		up = Input.GetKey (KeyCode.UpArrow);
		down = Input.GetKey (KeyCode.DownArrow);
		left = Input.GetKey (KeyCode.LeftArrow);
		right = Input.GetKey (KeyCode.RightArrow);

		zTrans = new Vector3 (0, 0, velocity);
		motionControl ();
		if(Input.GetKeyDown(KeyCode.Space)) {
			shoot ();
		}
	
	}

	void motionControl() {
		
		if (w && velocity < 2) {
			velocity = velocity + 0.1F;
		}
		if (s && velocity > 0) {
			velocity = velocity - 0.1F;
		}
		
		if (velocity < 0) {
			velocity = 0;
		}

		if (up) {
			transform.position = dodge (yTrans);
		}
		if (down) {
			transform.position = dodge (-yTrans);
		}
		if (left) {
			transform.position = dodge (-xTrans);
		}
		if (right) {
			transform.position = dodge(xTrans);
		}
		
		transform.position = Vector3.Lerp(transform.position, transform.position+zTrans, Time.deltaTime * smooth);
		
		if (velocity > 1f) {
			velocity = velocity - 0.05F;
		}

	}

	void shoot() {
		Vector3 position = new Vector3 (0, 0, 2);
		shoot (position, shooter.transform.rotation);
	}
	

	Vector3 dodge(Vector3 direction) {
		return transform.position = Vector3.Lerp (transform.position, transform.position + direction, Time.deltaTime * smooth);
	}
	

}
