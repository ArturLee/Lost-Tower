using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectIron : MonoBehaviour
{

    public Transform Player;
    public Text resourceValue;
    float resourceTimer = 0;
    public float gatherDelay;



    void Start()
    {
        GameObject counter = GameObject.Find("Player");
        GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));

        control.resourceCounter();
    }

    void Update()
    {
        resourceTimer -= Time.deltaTime;

        if (resourceTimer < 0)
        {
            resourceTimer = 0;
        }

        float dist = Vector3.Distance(Player.position, transform.position);
        if (dist < 2 && resourceTimer == 0)
        {
            GameObject.Find("Player").GetComponent<GameControl>().iron += 1; resourceTimer = gatherDelay;
            GameObject counter = GameObject.Find("Player");
            GameControl control = (GameControl)counter.GetComponent(typeof(GameControl));
            control.resourceCounter();
        }
    }

}
