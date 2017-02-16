using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCS : MonoBehaviour {
	
	public GameObject egg;
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
			randomPosition ();
		}
	}

	void randomPosition() {
		GameObject newEgg = GameObject.Instantiate (egg);

		float x = Random.Range(-27.5f, 27.5f);
		float z = Random.Range (-27.5f, 27.5f);

		newEgg.transform.position = new Vector3 (x, 0.5f, z);
	}
}
