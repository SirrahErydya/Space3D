using UnityEngine;
using System.Collections;

public class StarField : MonoBehaviour {

	//position
	private Transform tx;

	//stars 
	private ParticleSystem.Particle[] stars;
	private ParticleSystem ps;

	//star properties
	public int starsMax = 1000;
	public float minSize = 0.1f;
	public float maxSize = 0.5f;
	public float starDistance = 10;
	public float starClipDistance = 0.5f;
	public Vector3 superSpeed = new Vector3(0,0,1000);
	public Vector3 endStarfield = new Vector3(0,0,1500);

	private float starDistanceSqr;
	private float starClipDistanceSqr;



	// Use this for initialization
	void Start () {
		tx = transform;
		starDistanceSqr = starDistance * starDistance;
		starClipDistanceSqr = starClipDistance * starClipDistance;
		ps = GetComponent<ParticleSystem> ();

	}

	private void createStars() {
		stars = new ParticleSystem.Particle[starsMax];
		for (int i = 0; i < starsMax; i++) {
			stars[i].position = Random.insideUnitSphere * starDistance + tx.position;
			stars[i].color = randomColor();
			stars[i].size = Random.Range(minSize, maxSize);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (stars == null && tx.position.z <= endStarfield.z) {
			createStars();
		}

		if (tx.position.z > endStarfield.z) {
			stars = null;
		}

		for (int i=0; i < starsMax; i++) {
			if((stars[i].position - tx.position).sqrMagnitude > starDistanceSqr) {
				stars[i].position = Random.insideUnitSphere * starDistance + tx.position;
			}

			if((stars[i].position - tx.position).sqrMagnitude <= starClipDistanceSqr) {
				float percent = (stars[i].position - tx.position).sqrMagnitude / starClipDistanceSqr;
				stars[i].color = new Color (1,1,1, percent);
			}
		}
		ps.SetParticles(stars, stars.Length);
		if(tx.position.z >= superSpeed.z) {
			ParticleSystemRenderer r = (ParticleSystemRenderer) ps.GetComponent<ParticleSystemRenderer>();
			r.renderMode = ParticleSystemRenderMode.Stretch;
			ps.gameObject.GetComponent<ParticleRenderer>().particleRenderMode = ParticleRenderMode.Stretch;
		}
	}

	private Color randomColor() {
		Color color;
		int counter = Random.Range (0, 20);

		switch(counter) {

			case 0:
			color = new Color(1,0.2f,0,0.5f);
			break;

			case 1: case 3: case 6:
			color = new Color(0,1,1,1);
			break;

			case 2:
			color = new Color(1,0.92f,0.016f,0.5f);
			break;

			default:
			color = new Color(1,1,1,1);
			break;
		}

		return color;
	}
}
