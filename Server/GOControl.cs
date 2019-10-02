using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boomlagoon.JSON;
using UnityEngine.UI;

public class GOControl : MonoBehaviour {

    private static string url = "http://leedeveloper.ga/login_unity.php";

    [SerializeField]
    private Text feedbackmsg = null;

    private string username;
    private string password;
    string player;


	// Use this for initialization
	void Start () {
        
        player = LoginController.user;
        JSONObject json = JSONObject.Parse(player);
        username = json.GetString("username");
        password = json.GetString("password");

        LoginController.user = null;
	}

    public void doRetry(){
        if (username == "" || password == "")
        {
            feedbackError("Connection Problem");
        }
        else
        {

            WWW www = new WWW(url + "?username=" + username + "&password=" + password);
            StartCoroutine(Validation(www));
        }
    }
    public void exit()
    {
        Application.Quit();
    }
    IEnumerator Validation(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            player = www.text;
            JSONObject json = JSONObject.Parse(player);
            if (json == null)
            {
                feedbackError("Server ERROR 404..");
            }
            else if (json["success"].Boolean == true)
            {
                LoginController.user = player;
                feedbackOk("Success Login \n Loading ... ");
                StartCoroutine(loadscene());
            }
        }
        else
        {
            if (www.error == "couldn't connect to host")
            {
                feedbackError("Server down..");
            }
        }
    }
    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("MainMenu");
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
    }
}
