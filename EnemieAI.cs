using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAI : MonoBehaviour {

    public Transform target;
    public Transform target2;
    public Transform target3;
    public float chaseRange;
    public float speed;
    public float stopdist;

	public float health = 10;

    public List<Transform> Towers;
    public Transform SelectedTarget;

    public static int killya;

    // Use this for initialization
    void Start () {
		if(target==null)
			target = GameObject.FindWithTag ("player").transform;

		if(target2 == null)
			target2 = GameObject.FindWithTag ("lost_tower").transform;

        if (target3 == null)
            target3 = GameObject.FindWithTag("building").transform;

    }


    public void AddTowerToList()
    {
        GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("building");
        foreach (GameObject _Tower in ItemsInList)
        {
            AddTarget(_Tower.transform);
        }
    }

    public void AddTarget(Transform enemy)
    {
        Towers.Add(enemy);
    }

    public void DistanceToTarget()
    {
        Towers.Sort(delegate (Transform t1, Transform t2)
        {
            return Vector2.Distance(t1.transform.position, transform.position).CompareTo(Vector2.Distance(t2.transform.position, transform.position));
        });
    }

    public void TargetedTower()
    {
        if (SelectedTarget == null)
        {
            DistanceToTarget();
            SelectedTarget = Towers[0];
        }
    }


    void Update () {

	

        SelectedTarget = null;
        Towers = new List<Transform>();
        AddTowerToList();
        TargetedTower();
        float dist = Vector2.Distance(SelectedTarget.transform.position, transform.position);

        //get the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float distanceToTarget2 = Vector3.Distance(transform.position, target2.position);


        //rotate to tower
        Vector3 targetDir2 = target2.position - transform.position;
        float angle2 = Mathf.Atan2(targetDir2.y, targetDir2.x) * Mathf.Rad2Deg - 90f;
        Quaternion q2 = Quaternion.AngleAxis(angle2, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q2, 180);
        //chasing tower 
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (dist <= chaseRange)
        {
            Vector3 targetDir = SelectedTarget.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            if (dist > stopdist)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
        }

        if (distanceToTarget <= chaseRange){
            //rotate to player
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            //chasing player 

            if(distanceToTarget>stopdist){
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }

        }


        else if(transform.position.x >= -10 && transform.position.x <=10 &&
                  transform.position.y >= -10 && transform.position.y <=10 ){
            float x = 0;
            float y = 0;
            Vector3 pos = new Vector3(x, y) - transform.position;
            transform.Translate(pos.normalized * Time.deltaTime * speed);

        } else if(transform.position.x >= -15 && transform.position.x <= 15 &&
                  transform.position.y >= -15 && transform.position.y <= 15)
        {
            float x = Random.Range(transform.position.x, 5);
            float y = Random.Range(transform.position.y, 5);
            Vector3 pos = new Vector3(x, y) - transform.position;
            transform.Translate(pos.normalized * Time.deltaTime * speed);
        } 
        else if (transform.position.x >= -20 && transform.position.x <= 20 &&
                  transform.position.y >= -20 && transform.position.y <= 20)
        {
            float x = Random.Range(transform.position.x, 10);
            float y = Random.Range(transform.position.y, 10);
            Vector3 pos = new Vector3(x, y) - transform.position;
            transform.Translate(pos.normalized * Time.deltaTime * speed);
        }
        else if (transform.position.x >= -25 && transform.position.x <= 25 &&
                  transform.position.y >= -25 && transform.position.y <= 25)
        {
            float x = Random.Range(transform.position.x, 15);
            float y = Random.Range(transform.position.y, 15);
            Vector3 pos = new Vector3(x, y) - transform.position;
            transform.Translate(pos.normalized * Time.deltaTime * speed);
        }

    }
    private void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "woosh") {
			collision.gameObject.SetActive (false);        
		
			//Debug.Log("mayday");
			Destroy (collision.gameObject);
			health = health - 1;
		}

		if (collision.gameObject.tag == "BOOM") {
			collision.gameObject.SetActive (false);        

			//Debug.Log("mayday");
			Destroy (collision.gameObject);
			health = health - 2;
		}



		if (health <= 0) {
            //Debug.Log("gone");
            killya = killya + 1;
            Debug.Log(killya);
			Destroy (gameObject);
		}
	}
}
