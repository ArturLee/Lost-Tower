using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : MonoBehaviour {


	public float bomrad;
	public Collider2D[] col;
	public LayerMask layer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

	}



	void OnCollisionEnter2D (Collision2D collision)
	{ 
		col = Physics2D.OverlapCircleAll (transform.position, bomrad, layer);
		foreach (Collider2D hit in col) 
		{
			if (hit.gameObject.tag == "enemy") 
			{
				Destroy (hit.gameObject);
			}
		}

		if (collision.gameObject.tag == "enemy")
		{
			Destroy (gameObject);
		}
	}
}
