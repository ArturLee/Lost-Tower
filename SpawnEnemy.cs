using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {


	public GameObject meleeOne;
	public GameObject meleeTwo;
	public GameObject rangedOne;
	public GameObject rangedTwo;
	public GameObject thief;

#region Timer Variables
	float mainTimer = 0;

	float SpawnTimer = 0;
	public float spawnDelay;

	float cotOne = 0;
	float cotOneDelay = 2;

	float cotTwo = 0;
	float cotTwoDelay = 4.2f;

	float cotThree = 0;
	float cotThreeDelay = 3;

	float cotFour = 0;
	float cotFourDelay = 6.66f;

	float cotFive = 0;
	float cotFiveDelay = 60;
#endregion


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{ //print (mainTimer);

		SpawnTimer -= Time.deltaTime;

		if (SpawnTimer < 0)
		{
			SpawnTimer = 0;
		}

		if (SpawnTimer == 0)
		{
			mainTimer++;
			SpawnTimer = spawnDelay;
		}
	
#region Monster Timer
		cotOne -= Time.deltaTime;
		cotTwo -= Time.deltaTime;
		cotThree -= Time.deltaTime;
		cotFour -= Time.deltaTime;
		cotFive -= Time.deltaTime;

		if (cotOne < 0)
		{
			cotOne = 0;
		}

		if (cotTwo < 0)
		{
			cotTwo = 0;
		}

		if (cotThree < 0)
		{
			cotThree = 0;
		}

		if (cotFour < 0)
		{
			cotFour = 0;
		}

		if (cotFive < 0)
		{
			cotFive = 0;
		}
#endregion


		if (mainTimer >= 120 && cotOne == 0)
		{
			Instantiate (meleeOne, transform.position, transform.rotation);
			cotOne = cotOneDelay;
		}

		if (mainTimer >= 210 && cotTwo == 0)
		{
			Instantiate (meleeTwo, transform.position, transform.rotation);
			cotTwo = cotTwoDelay;
		}

		if (mainTimer >= 150  && cotThree == 0)
		{
			Instantiate (rangedOne, transform.position, transform.rotation);
			cotThree = cotThreeDelay;
		}

		if (mainTimer >= 180 && cotFour == 0)
		{
			Instantiate (rangedTwo, transform.position, transform.rotation);
			cotFour = cotFourDelay;
		}

		if (mainTimer >= 250 && cotFive == 0)
		{
			Instantiate (thief, transform.position, transform.rotation);
			cotFive = cotFiveDelay;
		}
	}
}