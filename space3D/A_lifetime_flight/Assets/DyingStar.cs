using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DyingStar : MonoBehaviour {

	//position
	private Transform tx;
	public Vector3 endStarfield = new Vector3(0,0,1500);

	private double speed;

	public Text message;
	private float opacity;


	

	//star
	private ParticleSystem dyingStar;

	// Use this for initialization
	void Start () {
		tx = transform;
		dyingStar = GetComponent<ParticleSystem>();
		message.text = "";

	
	}

	
	// Update is called once per frame
	void Update () {
		message.color = new Color (1, 1, 1, opacity);
		if (CameraMovement.FlyCamTx.position.z >= endStarfield.z) {
			dyingStar.playbackSpeed = dyingStar.playbackSpeed * 1.05f;
			speed = dyingStar.playbackSpeed;
		}


		if (speed >= 10000f) {
			message.text = "Not even stars last forever. \n Don't waste your time. \n It's never too late to be awesome.";
			if(opacity < 1) {
				opacity = opacity + 0.005f;
			}
		}
	
	}
}
