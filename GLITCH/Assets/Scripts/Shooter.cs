using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject projectileParent;
	public GameObject gun;

	private Animator animator;
	private Spawner myLaneSpawner;
	

	void Start ()
	{

		
		animator = GetComponent<Animator>();
		
		// creates a parent for projectiles if necessary
		projectileParent = GameObject.Find("Projectiles");

		if (!projectileParent)
		{
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner();
		
	}

		//look through all spawners and set mylanespawner if found
	void SetMyLaneSpawner ()
	{

		Spawner [] allSpawners = GameObject.FindObjectsOfType<Spawner>();
		foreach (Spawner playfieldSpawner in allSpawners)
		{
			if (playfieldSpawner.transform.position.y == transform.position.y)
			{
				myLaneSpawner = playfieldSpawner;
				print(myLaneSpawner);
				return; // This is how I broke my code
			}
			
		}

		Debug.LogError(name + "cannot find spawner in lane");
	}


	void Update ()
	{
		if (IsAttackerAheadInLane())
		{
			animator.SetBool("isAttacking", true);
		} else
		{
			animator.SetBool("isAttacking", false);
		}
	}


	bool IsAttackerAheadInLane()
	{
		if (myLaneSpawner.transform.childCount <= 0)
		{
			return false;
		}

		foreach (Transform attacker in myLaneSpawner.transform)
		{
			if (attacker.transform.position.x > transform.position.x)
			{
				return true;
			} 
		}
		// Attackers in lane but behind us
		return false;
	}

	private void Fire ()
	{

		GameObject newProjectile = Instantiate(projectile);
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
		

	}
}
