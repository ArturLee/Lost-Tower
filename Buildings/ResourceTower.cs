using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTower : MonoBehaviour
{

    private Transform wood1;
    private Transform iron1;
	private Transform wood2;
	private Transform iron2;
	private Transform wood3;
	private Transform iron3;
	private Transform wood4;
	private Transform iron4;
	private Transform wood5;
	private Transform iron5;
    
	private Transform food;

    float resourceTimer = 0;
	public float gatherDelay;

	public int health;



	void Start()
	{
		health = 10;
		if (food == null)
			
		wood1 = GameObject.Find("Wood 01").transform;
		iron1 = GameObject.Find("Iron 01").transform;
		wood2 = GameObject.Find("Wood 02").transform;
		iron2 = GameObject.Find("Iron 02").transform;
		wood3 = GameObject.Find("Wood 03").transform;
		iron3 = GameObject.Find("Iron 03").transform;
		wood4 = GameObject.Find("Wood 04").transform;
		iron4 = GameObject.Find("Iron 04").transform;

        if (food == null)
			food = GameObject.FindWithTag("food").transform;

        GameObject counter = GameObject.Find("Player");
        GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

        control.resourceCounter();

    }

    void Update()
	{
		resourceTimer -= Time.deltaTime;

		if (resourceTimer < 0)
		{
			resourceTimer = 0;
		}

		float distWood1 = Vector3.Distance(wood1.position, transform.position);
		float distIron1 = Vector3.Distance(iron1.position, transform.position);
		float distWood2 = Vector3.Distance(wood2.position, transform.position);
		float distIron2 = Vector3.Distance(iron2.position, transform.position);
		float distWood3 = Vector3.Distance(wood3.position, transform.position);
		float distIron3 = Vector3.Distance(iron3.position, transform.position);
		float distWood4 = Vector3.Distance(wood4.position, transform.position);
		float distIron4 = Vector3.Distance(iron4.position, transform.position);

        float distFood = Vector3.Distance(food.position, transform.position);

		if (distWood1 <= 2 && resourceTimer == 0)
		{
			GameObject.Find("Player").GetComponent<GameControl>().wood += 1; resourceTimer = gatherDelay;
			GameObject counter = GameObject.Find("Player");
			GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

			control.resourceCounter();
		}

		if (distIron1 <= 2 && resourceTimer == 0)
		{
			GameObject.Find("Player").GetComponent<GameControl>().iron += 1; resourceTimer = gatherDelay;
			GameObject counter = GameObject.Find("Player");
			GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

			control.resourceCounter();
		}
		if (distWood2 <= 2 && resourceTimer == 0)
		{
			GameObject.Find("Player").GetComponent<GameControl>().wood += 1; resourceTimer = gatherDelay;
			GameObject counter = GameObject.Find("Player");
			GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

			control.resourceCounter();
		}

		if (distIron2 <= 2 && resourceTimer == 0)
		{
			GameObject.Find("Player").GetComponent<GameControl>().iron += 1; resourceTimer = gatherDelay;
			GameObject counter = GameObject.Find("Player");
			GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

			control.resourceCounter();
		}
		if (distWood3 <= 2 && resourceTimer == 0)
		{
			GameObject.Find("Player").GetComponent<GameControl>().wood += 1; resourceTimer = gatherDelay;
			GameObject counter = GameObject.Find("Player");
			GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

			control.resourceCounter();
		}

		if (distIron3 <= 2 && resourceTimer == 0)
		{
			GameObject.Find("Player").GetComponent<GameControl>().iron += 1; resourceTimer = gatherDelay;
			GameObject counter = GameObject.Find("Player");
			GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

			control.resourceCounter();
		}
		if (distWood4 <= 2 && resourceTimer == 0)
		{
			GameObject.Find("Player").GetComponent<GameControl>().wood += 1; resourceTimer = gatherDelay;
			GameObject counter = GameObject.Find("Player");
			GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

			control.resourceCounter();
		}

		if (distIron4 <= 2 && resourceTimer == 0)
		{
			GameObject.Find("Player").GetComponent<GameControl>().iron += 1; resourceTimer = gatherDelay;
			GameObject counter = GameObject.Find("Player");
			GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

			control.resourceCounter();
		}

        if (distFood < 2 && resourceTimer == 0)
        {
            GameObject.Find("Player").GetComponent<GameControl>().food += 1; resourceTimer = gatherDelay;
            GameObject counter = GameObject.Find("Player");
            GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

            control.resourceCounter();
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
