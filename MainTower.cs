using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTower : MonoBehaviour {

    public static int healthcount;
	public Text healthTower;

	public GameObject T1;
	public GameObject T2;
	public GameObject T3;
	public GameObject T4;

	// Use this for initialization
	void Start () {
		healthcount = 100;
		HealthCountText();
				}
	
	// Update is called once per frame
	void Update () {
        if(healthcount <=0){
            
        }
		HealthCountText();

		if(healthcount<=80)
		{
			DestroyObject(T4);
		}

		if(healthcount<=60)
		{
			DestroyObject(T3);
		}

		if(healthcount<=40)
		{
			DestroyObject(T2);
		}

		if(healthcount<=20)
		{
			DestroyObject(T1);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "Pew") {
			healthcount = healthcount - 1;
			HealthCountText ();
			collision.gameObject.SetActive (false);
			Destroy (collision.gameObject);

		}
	}

	void HealthCountText(){
		healthTower.text = " " + healthcount.ToString();
	}

    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("GameOver");
    }
}
