using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	

	private Button[] buttonArray;
	private Text costText;

	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	void Start ()
	{
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();

		if (!costText)
		{
			Debug.LogWarning("The button has not cost text");
		}

		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();

	}

	

	void OnMouseDown ()
	{

		
		foreach (Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
			GetComponent<SpriteRenderer>().color = Color.white;

		selectedDefender = defenderPrefab;
		print(selectedDefender);

	}
}
