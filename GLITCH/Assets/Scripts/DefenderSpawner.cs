using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

	private GameObject defenderParent;
	private StarDisplay starDisplay;


	// Use this for initialization
	void Start()
	{

		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		Camera camera = FindObjectOfType<Camera>();

		defenderParent = GameObject.Find("Defenders");

		if (!defenderParent)
		{
			defenderParent = new GameObject("Defenders");
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnMouseDown()
	{
	
			Vector2 rawPos = CalculateWorldPointOfMouseClick();
			Vector2 roundedPos = SnapToGrid(rawPos);

		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defender>().starCost;

		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS )
		{
			SpawnDefender(roundedPos);

		}

		print("Insufficient stars");
	}

	private void SpawnDefender(Vector2 roundedPos)
	{
		GameObject newDefender = Instantiate(Button.selectedDefender, roundedPos, Quaternion.identity);
		newDefender.transform.parent = defenderParent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick()
	{

		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);

		Vector2 worldPos = Camera.main.ScreenToWorldPoint(weirdTriplet);

		return worldPos;
	}


	Vector2 SnapToGrid (Vector2 rawWorldPosition)
	{
		int newX = Mathf.RoundToInt(rawWorldPosition.x);
		int newY = Mathf.RoundToInt(rawWorldPosition.y);
		return new Vector2(newX, newY);
	}
}

