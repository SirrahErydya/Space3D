using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public GameObject enemy;
	public int enemyCount;
	public Vector3 enemyPosition;

	// Use this for initialization
	void Start () {
		for(int i=0; i < enemyCount; i++){
			Quaternion rotation = new Quaternion();
			if(i < (enemyCount-1)/2) {
				rotation.Set (0F,0F,-0.3F,1F);
			} else if( i > (enemyCount-1)/2) {
				rotation.Set(0F,0F,0.3F,1F);
			} else {
				rotation.Set(0,0,0,1);
			}
			spawnEnemy(new Vector3(enemyPosition.x + i*2, enemyPosition.y, enemyPosition.z), enemy.transform.rotation*rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void spawnEnemy(Vector3 position, Quaternion rotation) {
		Instantiate (enemy, position, rotation);
	}
}
