using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boomlagoon.JSON;


public class LoginController : MonoBehaviour {

    [SerializeField]
    private InputField userfield = null;
    [SerializeField]
    private InputField passfield = null;
    [SerializeField]
    private Text feedbackmsg = null;

    private static string url = "http://leedeveloper.ga/login_unity.php";

    public static string user;



	// Use this for initialization
	void Start () {

	}


    public void dologin(){
        if (userfield.text == "" || passfield.text == "") { 
            feedbackError("Empty field: \n check username or \n password field");
        }else
        {
            string username = userfield.text;
            string password = passfield.text;

            WWW www = new WWW(url + "?username=" + username + "&password=" + password);
            StartCoroutine(Validation(www));
        }
    }
    public void playtrial(){
        user = "{\"user_id\":\"0\",\"name\":\"Guest\",\"username\":\"guest\",\"password\":\"0\",\"hours_played\":\"0\",\"kills\":\"0\",\"lose\":\"0\",\"wood\":\"0\",\"stone\":\"0\",\"meat\":\"0\"}";
        JSONObject json = JSONObject.Parse(user);
        //user ='{"user_id":"0","name":"asterix","username":"asterix","password":"123123","hours_played":"0","kills":"0","lose":"0","wood":"0","stone":"0","meat":"0","success":true}';
        StartCoroutine(loadscene());
    }
    public void doRegist(){
        StartCoroutine(regiscene());
    }

    IEnumerator Validation(WWW www){
        yield return www;
        if(www.error == null){
            user = www.text;
            JSONObject json = JSONObject.Parse(user);
            if(json == null){
                feedbackError("Server ERROR 404..");
            }else if(json["success"].Boolean == true){
                feedbackOk("Success Login \n Loading ... ");
                StartCoroutine(loadscene());
            }
                
            if (www.text == "0null")
            {
                feedbackError(" NO BUENO \n Your password or username \n is wrong \n Try again ");
            }
        }else { 
            if(www.error == "couldn't connect to host"){
                feedbackError("Server down..");
            }
        }
    }
    IEnumerator loadscene(){
        yield return new WaitForSeconds(0);
        Application.LoadLevel("MainMenu");
    }
    IEnumerator regiscene()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("RegisterScene");
    }
    void feedbackOk(string msg)
    {
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.green;
        feedbackmsg.text = msg;
    }
    void feedbackError(string msg)
    {
        feedbackmsg.CrossFadeAlpha(100f, 0f, false);
        feedbackmsg.color = Color.red;
        feedbackmsg.text = msg;
        feedbackmsg.CrossFadeAlpha(0f, 2f, false);
        userfield.text = "";
        passfield.text = "";
    }
}
