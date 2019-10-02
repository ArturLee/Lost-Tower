using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour {

    public GameObject FirePrefab;
    public float fireDelay;
    float cooldownTimer = 0;
    public Transform target;
    public Transform target2;
	public Transform target3;
    public float range;

	public List<Transform> Towers;
	public Transform SelectedTarget;

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
		
	
	// Update is called once per frame
	void Update () {

		SelectedTarget = null;
		Towers = new List<Transform>();
		AddTowerToList();
		TargetedTower();

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer<0){
            cooldownTimer = 0;
        }

		float dist = Vector2.Distance(SelectedTarget.transform.position, transform.position);
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float distanceToTarget2 = Vector3.Distance(transform.position, target2.position);

        if(distanceToTarget < range && cooldownTimer==0){
            
            cooldownTimer = fireDelay;

            Instantiate(FirePrefab, transform.position, transform.rotation);

        }else if(distanceToTarget2< range && cooldownTimer==0){
            cooldownTimer = fireDelay;
            Instantiate(FirePrefab, transform.position, transform.rotation);
        }

		else if (dist < range && cooldownTimer == 0) {
				cooldownTimer = fireDelay;
				Instantiate (FirePrefab, transform.position, transform.rotation);
			}
	}
}
