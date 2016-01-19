using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {

	public float START_VELOCITY = 0F;
	public float VMAX = 1F;
	protected static float velocity;
	public static float Velocity {
		get { return velocity; }
	}

	public float smooth = 5.0F;
	public Transform shooter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void shoot(Vector3 position, Quaternion rotation) {
		Object shooterClone = Instantiate(shooter, transform.position+position, transform.rotation * rotation);
		Destroy ((shooterClone as Transform).gameObject, 5);
	}
	
}
