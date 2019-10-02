using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class towerButton : MonoBehaviour {

	public Toggle tower01;
	public Toggle tower02;
	public Toggle tower03;
	public Toggle tower04;
	public Toggle tower05;


	public GameObject towerOne;
	public GameObject towerTwo;
	public GameObject towerThree;
	public GameObject towerFour;
	public GameObject towerFive;

	[System.NonSerialized]
	public int towerToggle = 0;

	private Vector2 mousepos;

	void Start () {}
	
	void Update ()
	{
			


		if (tower01.isOn == true) {
			towerToggle = 1;
			Debug.Log ("Tower 01 is On");
		} else if (tower02.isOn == true) {
			towerToggle = 2;
			Debug.Log ("Tower 02 is On");
		} else if (tower03.isOn == true) {
			towerToggle = 3;
			Debug.Log ("Tower 03 is On");
		} else if (tower04.isOn == true) {
			towerToggle = 4;
			Debug.Log ("Tower 04 is On");
		} else if (tower05.isOn == true) {
			towerToggle = 5;
			Debug.Log ("Tower 05 is On");
		} else if (tower01.isOn == false && tower02.isOn == false && tower03.isOn == false && tower04.isOn == false && tower05.isOn == false) {
			towerToggle = 0;
			Debug.Log ("Tower is Off");
		}	


		if (!EventSystem.current.IsPointerOverGameObject ()) {
			
			if (Input.GetMouseButtonDown (0) && towerToggle == 1) {
				mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Instantiate (towerOne, mousepos, Quaternion.identity);
			} else if (Input.GetMouseButtonDown (0) && towerToggle == 2) {
				mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Instantiate (towerTwo, mousepos, Quaternion.identity);
			} else if (Input.GetMouseButtonDown (0) && towerToggle == 3) {
				mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Instantiate (towerThree, mousepos, Quaternion.identity);
			} else if (Input.GetMouseButtonDown (0) && towerToggle == 4) {
				mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Instantiate (towerFour, mousepos, Quaternion.identity);
			} else if (Input.GetMouseButtonDown (0) && towerToggle == 5) {
				mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Instantiate (towerFive, mousepos, Quaternion.identity);
			}
		}
	}
}