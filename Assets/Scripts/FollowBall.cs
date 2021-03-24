using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
	public GameObject firePoint;
	public GameObject ballPrefab;

	public float distance = 5;
	public float power;

	Quaternion pathTrial;

	public Rigidbody rb;
	public static bool respawn = false;

	private GameObject manager;
	private Spawner spawn;
	private bool counter = true;

	float currentDistance;
	bool handling = true;

	void Start()
	{
		manager = GameObject.Find("Manager");
		currentDistance = distance;
		rb = GetComponent<Rigidbody>();
		Predict();
	}
	void Destroy()
	{
		Destroy(gameObject);
	}

	void NewBall()
	{
		spawn.Spawn();
	}

	void Update()
	{
		if (handling)
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = currentDistance;
			transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
		}
		else if(counter)
		{
			spawn = manager.GetComponent<Spawner>();
			counter = false;
			Invoke("NewBall", 3);
			Invoke("Destroy", 8);
		}
	}
	public Vector3 calculateForce()
	{
		return transform.forward * power;
	}

	void Predict()
	{
		PredictionManager.instance.predict(ballPrefab, firePoint.transform.position, calculateForce());
	}
}
