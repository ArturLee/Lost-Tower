using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class InstructionController : MonoBehaviour {

	// Use this for initialization
    public void goback(){
        StartCoroutine(backmeup());
    }
    IEnumerator backmeup()
    {
        yield return new WaitForSeconds(0);
        Application.LoadLevel("MainMenu");
    }
}
