using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : MonoBehaviour {

	private Animator animator;
	private Defender defender;

	public float damage;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		defender = GetComponent<Defender>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		var obj = collider.gameObject;
		print(obj + "hit the pineapple");

		if (!obj.GetComponent<Attacker>())
		{
			return;
		}

		if (obj.GetComponent<Attacker>())
		{
			animator.SetBool("isAttacking", true);
			defender.Attack(obj);
		}
		

	}
}
