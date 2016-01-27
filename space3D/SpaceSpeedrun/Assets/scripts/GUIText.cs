using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIText : MonoBehaviour {

	private float speed;
	private float kms;
	private float velocity;
	private float acc;
	private Text speedCounter;
	private static float LIGHTSPEED_KMS = 300000F;
	private static float LIGHTYEAR_PER_SEC = 31500000F;

	// Use this for initialization
	void Start () {
		speed = 10F;
		acc = 1.0000032F;
		velocity = 1F;
		speedCounter = GetComponent<Text> ();
		kms = speed * LIGHTSPEED_KMS;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space) && CameraMovement.Velocity < 0.3F) {
			velocity = velocity * acc;
			speed = speed * velocity;
			kms = speed * LIGHTSPEED_KMS;
		}
		if (speed < LIGHTYEAR_PER_SEC) {
			speedCounter.text = "Speed: " + speed + "x Lightspeed, " + kms + " km/s";
		} else {
			speedCounter.text = "Speed: " + speed / LIGHTYEAR_PER_SEC + "Lightyears per second, " + kms + " km/s";
		}
	}

}
