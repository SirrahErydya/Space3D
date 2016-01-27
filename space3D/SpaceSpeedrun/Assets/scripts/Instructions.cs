using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instructions : MonoBehaviour {

	private Text text;
	float change = 0.1F;
	bool stop;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.color = new Color(1,1,1,0);
		stop = false;
		startText ();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (startText ());
		if (CameraMovement.Velocity >= 0.3F) {
			StartCoroutine(setFinalText ());
		}
	}

	IEnumerator startText() {
		text.text = "Versuche, so schnell zu fliegen, wie es geht. \n Oben rechts steht deine Geschwindigkeit. \n Mit der Leertaste beschleunigst du.";
		StartCoroutine(fadeIn ());
		if (text.color.a >= 0.99F) {
			stop = true;
		}
		yield return new WaitForSeconds(5);
		StartCoroutine(fadeOut ());
	}

	IEnumerator setFinalText() {
		yield return new WaitForSeconds(12);
		text.text = "A really informative text";
		StartCoroutine(fadeIn ());
	}

	IEnumerator fadeIn(){
		
		while (text.color.a < 1 && !stop){
			float alpha = text.color.a + 0.1F * Time.deltaTime * 0.05F;
			text.color = new Color(1,1,1, alpha);
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator fadeOut() {
		while (text.color.a > 0) {
			float alpha = text.color.a - 0.1F * Time.deltaTime * 0.05F;
			text.color = new Color (1, 1, 1, alpha);
			yield return new WaitForEndOfFrame ();
		}
	}
	


}
