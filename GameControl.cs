using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Boomlagoon.JSON;

public class GameControl : MonoBehaviour
{

    public Toggle tower01;
    public Toggle tower02;
    public Toggle tower03;
    public Toggle tower04;
    public Toggle tower05;

    public Text woodValue;
    public Text ironValue;
    public Text foodValue;

    public GameObject towerOne;
    public GameObject towerTwo;
    public GameObject towerThree;
    public GameObject towerFour;
    public GameObject towerFive;

    [System.NonSerialized]
    public int towerToggle = 0;

    private Vector2 mousepos;

    public float speed;
    public static bool move;
    public GameObject point;
    private Vector3 target;

    public int healthcount = 10;
    public Text healthValue;

    public int wood;
    public int iron;
    public int food;

    public int price01 = 50;
    public int price02 = 150;
    public int price03 = 300;
    public int price04 = 500;
    public int price05 = 1000;

    private float starttempo;
    private float ftime = 0;
    private float kills = 0;
    private static string url = "http://leedeveloper.ga/update_status.php";

    // Use this for initialization
    void Start()
    {
        wood = Convert.ToInt32(ResourceController.woodval);
        iron = Convert.ToInt32(ResourceController.stoneval);
        healthcount = healthcount + Convert.ToInt32(ResourceController.meatval);

        //como fazemos com o food? eu fiz assim
        starttempo = Time.time;
        //Debug.Log(starttempo);

        HealthCountText();

        if (woodValue == null)
            woodValue = CanvasManager.instance.woodResource;
        if (ironValue == null)
            ironValue = CanvasManager.instance.ironResource;
        //if (foodValue == null)
            //foodValue = CanvasManager.instance.foodResource;
    }

    // Update is called once per frame
    void Update()
    {

        HealthCountText();
        resourceCounter();
        //Debug.Log(healthcount);
        if (tower01.isOn == true)
        {
            towerToggle = 1;
            //Debug.Log("Tower 01 is On");
        }
        else if (tower02.isOn == true)
        {
            towerToggle = 2;
            //Debug.Log("Tower 02 is On");
        }
        else if (tower03.isOn == true)
        {
            towerToggle = 3;
            //Debug.Log("Tower 03 is On");
        }
        else if (tower04.isOn == true)
        {
            towerToggle = 4;
            //Debug.Log("Tower 04 is On");
        }
        else if (tower05.isOn == true)
        {
            towerToggle = 5;
            //Debug.Log("Tower 05 is On");
        }
        else if (tower01.isOn == false && tower02.isOn == false && tower03.isOn == false && tower04.isOn == false && tower05.isOn == false)
        {
            towerToggle = 0;
            //Debug.Log("Tower is Off");
        }


        if (!EventSystem.current.IsPointerOverGameObject())
        {

            if (Input.GetMouseButtonDown(0) && towerToggle == 1 && wood >= price01 && iron >= price01)
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(towerOne, mousepos, Quaternion.identity);
                wood -= price01;
                iron -= price01;
            }
            if (Input.GetMouseButtonDown(0) && towerToggle == 2 && wood >= price02 && iron >= price02)
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(towerTwo, mousepos, Quaternion.identity);

                wood -= price02;
                iron -= price02;
            }
            if (Input.GetMouseButtonDown(0) && towerToggle == 3 && wood >= price03 && iron >= price03)
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(towerThree, mousepos, Quaternion.identity);

                wood -= price03;
                iron -= price03;
            }
            if (Input.GetMouseButtonDown(0) && towerToggle == 4 && wood >= price04 && iron >= price04)
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(towerFour, mousepos, Quaternion.identity);

                wood -= price04;
                iron -= price04;
            }
            if (Input.GetMouseButtonDown(0) && towerToggle == 5 && wood >= price05 && iron >= price05)
            {
                mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(towerFive, mousepos, Quaternion.identity);

                wood -= price05;
                iron -= price05;
            }
        }


        if (!EventSystem.current.IsPointerOverGameObject() && towerToggle == 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("mouse is prsessed");
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;

                //player rotation
                float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90);

                if (move == false)
                {
                    move = true;
                }

                Instantiate(point, target, Quaternion.identity);

            }
        }
        if (move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if (healthcount == 0)
        { 
            updatedatabase();
            healthcount = -100;
        }

        int towerhealth = MainTower.healthcount;
        if(towerhealth == 0){
            updatedatabase();
            healthcount = -100;
        }

        
    }
    void updatedatabase(){
        
            ftime = Time.time - starttempo;
            string minutes = ((int)ftime / 1).ToString();// /60 give minute /1 give seconds ok?
            string seconds = (ftime % 60).ToString("f0");
            //Debug.Log(minutes + ":" + seconds);
            string player = LoginController.user;
            JSONObject json = JSONObject.Parse(player);
            string username = json.GetString("username");
            int kill = EnemieAI.killya;
            string killa = Convert.ToString(kill);
           // Debug.Log("killas" + killa);
        WWW www = new WWW(url + "?hp=" + minutes + "&kills=" + killa + "&lose=1&username=" + username);
            //Debug.Log(url + "?hp=" + seconds + "&kills=" + killa + "&lose=1&username=" + username);
            StartCoroutine(Validation(www));
            
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Pew")
        {
            healthcount = healthcount - 1;
            HealthCountText();
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);

        }
    }
    void HealthCountText()
    {
        healthValue.text = healthcount.ToString();
    }

    public void resourceCounter()
    {
		woodValue.text = " " + wood.ToString();
		ironValue.text = " " + iron.ToString();
        //foodValue.text = "Food: " + food.ToString();
    }
    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("GameOver");
    }
    IEnumerator Validation(WWW www)
    {   
        yield return www;
        StartCoroutine(loadscene());
    }
}