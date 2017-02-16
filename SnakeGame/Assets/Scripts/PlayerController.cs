using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject preBody;
	private GameObject[] bodies;
	private float timer = 0f;
	private Vector3 forward = Vector3.forward;

	public int count;
	public bool isDead = false;

	private AudioSource eatSound;

	void Start () {
		bodies = new GameObject[100];
		bodies [0] = gameObject;
		bodies [1] = preBody;
		count = 2;

		eatSound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		forward = currentForward();
		timer += Time.deltaTime;

		if (timer > 0.25f) {
			followHead ();
			transform.position += forward;
			timer = 0f;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Egg") {
			grow ();
			eatSound.Play ();
		}

		if (other.gameObject.tag == "Wall") {
			forward = Vector3.zero;
			isDead = true;
		}
	}

	Vector3 currentForward() {
		if (Input.GetKeyDown (KeyCode.W)) {
			return Vector3.forward;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			return Vector3.back;
		} else if (Input.GetKeyDown (KeyCode.A)) {
			return Vector3.left;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			return Vector3.right;
		} else {
			return forward;
		}
	}

	void followHead() {
		if (!isDead) {
			for (int i = count - 1; i > 0; i--) {
				bodies [i].transform.position = bodies [i - 1].transform.position;
			}
		}
	}

	void grow() {
		GameObject newBody = GameObject.Instantiate (preBody);
		bodies [count] = newBody;
		count++;
	}
}
