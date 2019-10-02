using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow03 : MonoBehaviour
{

    private float rightBound;
    private float leftBound;
    private float topBound;
    private float bottomBound;
    private Vector3 pos;


    private Transform target;

    private Camera cam;
    public Bounds bounds;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("player").transform;


    


        cam = this.gameObject.GetComponent<Camera>();
        float camVertExtent = cam.orthographicSize;
        float camHorzExtent = cam.aspect * camVertExtent;




        leftBound = bounds.min.x + camHorzExtent;
        rightBound = bounds.max.x - camHorzExtent;
        bottomBound = bounds.min.y + camVertExtent;
        topBound = bounds.max.y - camVertExtent;

  
    }

    // Update is called once per frame
    void Update()
    {


        float camX = Mathf.Clamp(target.transform.position.x, leftBound, rightBound);
        float camY = Mathf.Clamp(target.transform.position.y, bottomBound, topBound);

        cam.transform.position = new Vector3(camX, camY, cam.transform.position.z);
    }

}