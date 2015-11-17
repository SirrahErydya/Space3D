using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float velocity = 0.1F;
	public float acceleration = 1F;
	public float increase = 1.0001F;

	private static Transform tx;
	

	// Use this for initialization
	void Start () {
		tx = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			acceleration = acceleration * increase;
			velocity = velocity * acceleration;
		}


		transform.Translate (0,0,velocity);

	}
}
