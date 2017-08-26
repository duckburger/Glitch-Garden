using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	private StarDisplay starDisplay;
	private GameObject currentTarget;
	private Animator animator;

	public int starCost = 20;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		animator = GetComponent<Animator>();
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

	public void Attack(GameObject obj)
	{
		currentTarget = obj;
	}


	// Update is called once per frame
	void Update () {

		if (!currentTarget)
		{
			animator.SetBool("isAttacking", false);
		}
	}

	public void AddStars (int amount)
	{
		starDisplay.AddStars(amount);
	}
}
