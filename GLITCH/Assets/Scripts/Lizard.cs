using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour {

	private Attacker attacker;
	private Animator animator;
	public float lizardDamage;

	// Use this for initialization
	void Start () {
		attacker = GetComponent<Attacker>();
		animator = GetComponent<Animator>();
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

		animator.SetBool("isAttacking", true);
		attacker.Attack(obj);
	}

	/*void OnTriggerExit2D ()
	{
		animator.SetBool("isAttacking", false);
	}*/
}
