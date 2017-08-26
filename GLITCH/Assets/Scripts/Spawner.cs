using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	
	public GameObject[] attackerPrefab;

	

	// Update is called once per frame
	void Update () {

		foreach (GameObject thisAttacker in attackerPrefab)
		{
			if (isTimeToSpawn(thisAttacker))
			{
				Spawn(thisAttacker);
			}
		}

	}

	bool isTimeToSpawn (GameObject attackerGameObject)
	{
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay)
		{
			Debug.LogWarning("Spawn rate is capped by frame rate");
		}

		float spawnThreshold = spawnsPerSecond * Time.deltaTime / 5;

		return (Random.value < spawnThreshold);
	}

	void Spawn (GameObject attackerSpawned)
	{
		GameObject attackerSpawner = Instantiate(attackerSpawned);
		attackerSpawner.transform.parent = transform;
		attackerSpawner.transform.position = transform.position;
	}
}
