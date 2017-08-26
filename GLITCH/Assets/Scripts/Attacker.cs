﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

		if (!currentTarget)
		{
			animator.SetBool("isAttacking", false);
		}
	}


	void OnTriggerEnter2D (Collider2D collider)
	{
		
	}

	public void SetSpeed (float speed)
	{
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget (float damage)
	{

		if (currentTarget)
		{
			Debug.Log(name + " Is striking something for " + damage + " damage");
			Health health = currentTarget.GetComponent<Health>();
			if (health)
			{
				health.DealDamage(damage);
			}
		}

		
	}


	public void Attack (GameObject obj)
	{
		currentTarget = obj;
		

		
	}
}
