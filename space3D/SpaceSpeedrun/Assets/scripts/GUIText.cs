using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIText : MonoBehaviour {

	private float speed;
	private float velocity;
	private float acc;
	private Text speedCounter;

	// Use this for initialization
	void Start () {
		speed = 3600F;
		acc = 1.000095F;
		velocity = 1F;
		speedCounter = GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space) && CameraMovement.velocity < 0.1F) {
			velocity = velocity * acc;
			speed = speed * velocity;
		}
		speedCounter.text = "Speed: " + speed + " Lightyears/second";
	}

}
