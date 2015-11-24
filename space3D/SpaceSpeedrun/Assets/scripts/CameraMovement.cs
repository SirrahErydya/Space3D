using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public static float velocity = 0.001F;
	public float acceleration = 1F;
	public float increase = 1.001F;

	private static Transform tx;
	

	// Use this for initialization
	void Start () {
		tx = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)&& velocity < 0.1) {
			acceleration = acceleration * increase;
			velocity = velocity * acceleration;
		}


		transform.Translate (0,0,velocity);

	}
}
