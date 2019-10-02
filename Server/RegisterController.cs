using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class RegisterController : MonoBehaviour {
    [SerializeField]
    private InputField namefield = null;
    [SerializeField]
    private InputField usernamefield = null;
    [SerializeField]
    private InputField passwordfield = null;
    [SerializeField]
    private InputField passwordfield2 = null;
    [SerializeField]
    private Text feedbackmsg = null;
	// Use this for initialization

    private static string url = "http://leedeveloper.ga/register_unity.php";
	void Start () {
		
	}

    public void doRegister(){
        /*if(namefield == "" || usernamefield == "" || passwordfield=="" || passwordfield2==""){
            feedbackError("Empty field: \n check namefield  \n username field \n password field");
        }else */if(passwordfield.text != passwordfield2.text){
            feedbackError("Password field does not match");
        }
        else{
            string name = namefield.text;
            string usern = usernamefield.text;
            string pass = passwordfield.text;

            WWW www = new WWW(url + "?name=" + name + "&username=" + usern + "&password=" + pass);
            StartCoroutine(Validation(www));
        }
    }
    public void retunrbtn()
    {
        StartCoroutine(returnscene());
    }
    IEnumerator Validation(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            LoginController.user = www.text;
            JSONObject json = JSONObject.Parse(LoginController.user);
            if (json == null)
            {
                feedbackError("Server ERROR 404..");
            }
            else if (json["success"].Boolean == true)
            {
                feedbackOk("Success Registration \n Loading ... ");
                StartCoroutine(loadscene());
            }

            if (www.text == "0null")
            {
                feedbackError(" NO BUENO \n Your password or username \n is wrong \n Try again ");
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
    IEnumerator returnscene()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("LoginScene");
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
        namefield.text = "";
        usernamefield.text = "";
        passwordfield.text = "";
        passwordfield2.text = "";
    }
}
