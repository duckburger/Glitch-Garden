using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		var obj = collider.gameObject;

		if (!obj.GetComponent<Attacker>())
		{
			return;
		} else
		{
			obj.GetComponent<Health>().DealDamage(damage);
			Destroy(gameObject);
		} 
	}
}
