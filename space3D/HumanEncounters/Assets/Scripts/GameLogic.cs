using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public GameObject enemy;
	public GameObject niceOne;
	private GameObject[] enemies;
	public int enemyCount;
	public Vector3 enemyPosition;
	public float smooth;

	// Use this for initialization
	void Start () {

		for (int i=0; i < enemyCount; i++) {
			/*Quaternion rotation = new Quaternion();
			if(i < (enemyCount-1)/2) {
				rotation.Set (0F,0F,-0.3F,1F);
			} else if( i > (enemyCount-1)/2) {
				rotation.Set(0F,0F,0.3F,1F);
			} else {
				rotation.Set(0,0,0,1);
			}*/
			int difference;
			if (i < (enemyCount - 1) / 2) {
				spawnEnemy (new Vector3 (enemyPosition.x + i * 2, enemyPosition.y + 2-i, enemyPosition.z - i), enemy.transform.rotation);
			} else {
				spawnEnemy (new Vector3 (enemyPosition.x + i * 2, enemyPosition.y + i-2, enemyPosition.z + i - 4), enemy.transform.rotation);
			}
		}
		Instantiate (niceOne, new Vector3 (enemyPosition.x + 4, enemyPosition.y, enemyPosition.z+5), niceOne.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void spawnEnemy(Vector3 position, Quaternion rotation) {
		Instantiate (enemy, position, rotation);
	}


}
