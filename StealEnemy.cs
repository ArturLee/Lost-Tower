using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealEnemy : MonoBehaviour {

	public Transform target;
	public Transform target2;
	public Transform target3;
	public float chaseRange;
	public float speed;
	public float stopdist;

	public LayerMask layer;


	public float health = 10;

	float stealTimer = 0;
	public float stealDelay;

	public List<Transform> Towers;
	public Transform SelectedTarget;


	// Use this for initialization
	void Start () {
		if(target==null)
			target = GameObject.FindWithTag ("player").transform;
			}





	void Update () {
		speed = 3;
		stealTimer -= Time.deltaTime;

		if (stealTimer < 0) {
			stealTimer = 0;
		}
			
		float distanceToTarget = Vector3.Distance(transform.position, target.position);

			//rotate to player
			Vector3 targetDir = target.position - transform.position;
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
			//chasing player 

			if(distanceToTarget>stopdist){
				transform.Translate(Vector3.up * Time.deltaTime * speed);
			}
			


		else if(transform.position.x >= -10 && transform.position.x <=10 &&
			transform.position.y >= -10 && transform.position.y <=10 ){
			float x = 0;
			float y = 0;
			Vector3 pos = new Vector3(x, y) - transform.position;
			transform.Translate(pos.normalized * Time.deltaTime * speed);

		} else if(transform.position.x >= -15 && transform.position.x <= 15 &&
			transform.position.y >= -15 && transform.position.y <= 15)
		{
			float x = Random.Range(transform.position.x, 5);
			float y = Random.Range(transform.position.y, 5);
			Vector3 pos = new Vector3(x, y) - transform.position;
			transform.Translate(pos.normalized * Time.deltaTime * speed);
		} 
		else if (transform.position.x >= -20 && transform.position.x <= 20 &&
			transform.position.y >= -20 && transform.position.y <= 20)
		{
			float x = Random.Range(transform.position.x, 10);
			float y = Random.Range(transform.position.y, 10);
			Vector3 pos = new Vector3(x, y) - transform.position;
			transform.Translate(pos.normalized * Time.deltaTime * speed);
		}
		else if (transform.position.x >= -25 && transform.position.x <= 25 &&
			transform.position.y >= -25 && transform.position.y <= 25)
		{
			float x = Random.Range(transform.position.x, 15);
			float y = Random.Range(transform.position.y, 15);
			Vector3 pos = new Vector3(x, y) - transform.position;
			transform.Translate(pos.normalized * Time.deltaTime * speed);
		}
	}


	private void OnCollisionStay2D(Collision2D collision)
	{

		if (collision.gameObject.name == "Player" && stealTimer == 0)
		{
			if (collision.gameObject.GetComponent<GameControl> ().iron > 0)
			{
				collision.gameObject.GetComponent<GameControl> ().iron -= 1;
			}

			if (collision.gameObject.GetComponent<GameControl> ().wood > 0)
			{
				collision.gameObject.GetComponent<GameControl> ().wood -= 1;
			}

			if (collision.gameObject.GetComponent<GameControl> ().food > 0)
			{
				collision.gameObject.GetComponent<GameControl> ().food -= 1;
			}

			speed=0;
			stealTimer = stealDelay;
		}

	}




	private void OnCollisionEnter2D (Collision2D collision)
	{

		if (collision.gameObject.tag == "woosh") {
			collision.gameObject.SetActive (false);        

			//Debug.Log("mayday");
			Destroy (collision.gameObject);
			health = health - 1;
		}
		
		if (collision.gameObject.tag == "BOOM") {
			collision.gameObject.SetActive (false);        

			//Debug.Log("mayday");
			Destroy (collision.gameObject);
			health = health - 2;
		}



			if (health <= 0) {
			//Debug.Log("gone");
            int killya = EnemieAI.killya;
            killya = killya + 1;
            Debug.Log(killya);
			Destroy (gameObject);
			}
		}
	}
