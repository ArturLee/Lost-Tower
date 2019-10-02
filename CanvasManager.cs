using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
	static public CanvasManager instance;

    public Text woodResource;
    public Text ironResource;
    //public Text foodResource;



    // Use this for initialization
    void Start () {
		instance = this;
	}

}
