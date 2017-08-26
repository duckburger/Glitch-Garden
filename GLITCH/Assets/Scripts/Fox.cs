using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	public float foxDamage;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		var obj = collider.gameObject;

		if (!obj.GetComponent<Defender>())
		{
			return;
		}

		if (obj.GetComponent<StarTrophy>())
		{
			animator.SetTrigger("isJumping");
		} else if (obj.GetComponent<Cactus>())
		{
			animator.SetBool("isAttacking", true);
			attacker.Attack(obj);
		} else if (obj.GetComponent<Bear>())
		{
			animator.SetBool("isAttacking", true);
			attacker.Attack(obj);
		} else if (obj.GetComponent<Pineapple>())
		{
			animator.SetTrigger("isJumping");
		}
	}
}
