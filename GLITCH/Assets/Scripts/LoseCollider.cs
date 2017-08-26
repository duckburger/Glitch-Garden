using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {


	private LevelManager levelManager;

	

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D()
	{
		levelManager.ShowLoseScreen();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
