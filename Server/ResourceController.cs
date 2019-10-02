using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class ResourceController : MonoBehaviour {

    [SerializeField]
    private Text firstname = null;
    [SerializeField]
    private Text meatfield = null;
    [SerializeField]
    private Text woodfield = null;
    [SerializeField]
    private Text stonefield = null;
    [SerializeField]
    private InputField inputmeat = null;
    [SerializeField]
    private InputField inputwood = null;
    [SerializeField]
    private InputField inputstone = null;

    private static string url = "http://leedeveloper.ga/update_resources.php";

    public static string woodval = "0";
    public static string stoneval = "0";
    public static string meatval = "0";


        string player;
	// Use this for initialization
	void Start () {
        player = LoginController.user;
        JSONObject json = JSONObject.Parse(player);
        string namee = json.GetString("name");
        string wood = json.GetString("wood");
        string stone = json.GetString("stone");
        string meat = json.GetString("meat");
        userplayername(namee);
        meatfield.text = "Extra meat: "+meat;
        woodfield.text = "Extra wood: " +wood;
        stonefield.text ="Extra stone: " +stone;
	}

    public void slider()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void play()
    {
        if(inputwood.text == ""){
            inputwood.text = "0";
        }else if(inputstone.text == ""){
            inputstone.text = "0";
        }else if(inputmeat.text == "0"){
            inputmeat.text = "0";
        }
        woodval = inputwood.text;
        stoneval = inputstone.text;
        meatval = inputmeat.text;
        player = LoginController.user;
        JSONObject json = JSONObject.Parse(player);
        string username = json.GetString("username");
        WWW www = new WWW(url + "?wood=" + woodval + "&stone=" + stoneval + "&meat=" + meatval + "&username=" + username);
        StartCoroutine(loadscene());
    }
    public void retunrbtn()
    {
        StartCoroutine(returnscene());
    }

    void userplayername(string _name)
    {
        firstname.CrossFadeAlpha(100f, 0f, false);
        firstname.text = _name;

    }
    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("Lost Tower");
    }
    IEnumerator returnscene()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("MainMenu");
    }
}
