using UnityEngine;
using System.Collections;

public class TargetFollower : MonoBehaviour {

	public Transform target;
	private float smooth = 5.0F;
	private Vector3 zDifference;

	void Start () {
		zDifference = new Vector3 (0, 0, -3);

	}

	void Update() {
		if (target != null) {
			transform.position = Vector3.Lerp (transform.position, target.position + zDifference, Time.deltaTime * smooth);
		}
	}
}
