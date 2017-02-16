using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCS : MonoBehaviour {

	public GameObject head;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - head.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, head.transform.position + offset, 0.1f);
	}
}
