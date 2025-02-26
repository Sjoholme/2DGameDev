using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public float speed;
	private float waitTime;
	public float startWaitTime;

	public Transform[] moveSpots;
	private int randomSpot;

	bool left;
	bool right;


	Animator anim;
	bool isIdle =false;

	void Start(){
		waitTime = startWaitTime;
		randomSpot = Random.Range (0, moveSpots.Length);
	}

	void awake (){
		anim = GetComponent<Animator>();
	}

	void Update(){
		transform.position = Vector2.MoveTowards (transform.position, moveSpots [randomSpot].position, speed * Time.deltaTime);

	
		if (Vector2.Distance (transform.position, moveSpots [randomSpot].position) < 0.2f) {
			if (waitTime <= 0) {
				randomSpot = Random.Range (0, moveSpots.Length);
				waitTime = startWaitTime;
				isIdle = true;

			} else {
				waitTime -= Time.deltaTime;
				isIdle = false;
			}
		
		}

		if (transform.position.x < moveSpots [randomSpot].position.x) {
				transform.rotation = Quaternion.identity;
			}
			else{
				transform.rotation = Quaternion.Euler(0,180,0);
			}
	}
}
