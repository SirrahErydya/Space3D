using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float velocity = 0.1F;
	public float acceleration = 1.001F;

	private static Transform tx;
	public static Transform FlyCamTx {
		get { return tx;}
	}

	public Vector3 endStarfield = new Vector3(0,0,1500);

	// Use this for initialization
	void Start () {
		tx = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		velocity = velocity * acceleration;
		transform.Translate (0,0,velocity);
		if (velocity > 10) {
			acceleration = 1;
		}
		if (tx.position.z > endStarfield.z) {
			velocity = 0;
		}
	}
}
