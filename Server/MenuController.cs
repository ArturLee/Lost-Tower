using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class MenuController : MonoBehaviour {

    [SerializeField]
    private Text firstname = null;

    string player;
	// Use this for initialization
	void Start () {
        player = LoginController.user;
        JSONObject json = JSONObject.Parse(player);
        string namee = json.GetString("name");
        userplayername(namee);
	}

    void userplayername(string _name){
        firstname.CrossFadeAlpha(100f, 0f, false);
        firstname.text = _name;
    }
    public void play(){
        StartCoroutine(loadscene());
    }
    public void Help(){
        StartCoroutine(instruction());
    }    
    public void exit(){
        Application.Quit();
    }
    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("ResourceM");
    }
    IEnumerator instruction()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("Instructions");
    }
	
	// Update is called once per frame
	void Update () {
	}
}
