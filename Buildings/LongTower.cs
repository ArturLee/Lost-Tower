using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFire : MonoBehaviour
{

	public GameObject fireobj;
	public float firedelay;
	float cooldownTimer = 0;
	public List<Transform> Enemies;
	public Transform SelectedTarget;
	public float range;
	public int health;


	void Start()
	{
		health = 10;

	}

	public void AddEnemiesToList()
	{
		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("enemy");
		foreach (GameObject _Enemy in ItemsInList)
		{
			AddTarget(_Enemy.transform);
		}
	}

	public void AddTarget(Transform enemy)
	{
		Enemies.Add(enemy);
	}

	public void DistanceToTarget()
	{
		Enemies.Sort(delegate (Transform t1, Transform t2)
			{
				return Vector2.Distance(t1.transform.position, transform.position).CompareTo(Vector2.Distance(t2.transform.position, transform.position));
			});
	}

	public void TargetedEnemy()
	{
		if (SelectedTarget == null)
		{
			DistanceToTarget();
			SelectedTarget = Enemies[0];
		}
	}
	// Update is called once per frame
	void Update()
	{
		SelectedTarget = null;
		Enemies = new List<Transform>();
		AddEnemiesToList();
		cooldownTimer -= Time.deltaTime;
		TargetedEnemy();
		float dist = Vector2.Distance(SelectedTarget.transform.position, transform.position);

		if (cooldownTimer < 0)
		{
			if (dist <= range && cooldownTimer <= 0)
			{
				Debug.Log("shoooooooot");
				cooldownTimer = firedelay;
				Vector3 targetDir = SelectedTarget.position - transform.position;
				float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
				Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
				Instantiate(fireobj, transform.position, transform.rotation);
			}
		}
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
