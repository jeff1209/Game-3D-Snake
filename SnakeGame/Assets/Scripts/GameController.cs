using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text scoreLabel;
	public Text deadLabel;
	public AudioClip deadClip;
	private GameObject snake;
	private PlayerController playerController;
	private AudioSource BGM;

	// Use this for initialization
	void Start () {
		snake = GameObject.FindGameObjectWithTag ("Player");
		playerController = snake.GetComponent<PlayerController> ();
		BGM = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		int score = playerController.count - 2;
		scoreLabel.text = "Score: " + score.ToString ();
		if (playerController.isDead) {
			deadLabel.text = "Game Over!";
			if (BGM.isPlaying) {
				BGM.Stop ();
				AudioSource.PlayClipAtPoint (deadClip, transform.position);
			}
		}
	}
}
