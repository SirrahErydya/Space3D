using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private static float velocity = 0.001F;
	public static float Velocity { 
		get { return velocity;}
	}
			
	private float acceleration = 1.000001F;
	private float increase = 1.000001F;

	private static Transform tx;
	

	// Use this for initialization
	void Start () {
		tx = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)&& velocity < 0.3) {
			acceleration = acceleration * increase;
			velocity = velocity * acceleration;
		}
		//For Debugging
		if (Input.GetKey (KeyCode.D)) {
			velocity = 0.3F;
		}


		transform.Translate (0,0,velocity);


	}


}
