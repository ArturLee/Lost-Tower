using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTower : MonoBehaviour {
	 public int health;


	void Start()
	{
		health = 50;

	}

	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnCollisionStay2D (Collision2D collision)
	{

	
		if (collision.gameObject.tag == "Pew") {
			//Debug.Log("mayday");
			collision.gameObject.SetActive (false);
			Destroy (collision.gameObject);
			health = health - 1;
		}
		if (health <= 0) {
			//Debug.Log("gone");
			Destroy (gameObject);
		}
	}
}
