using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{

	public float fadeInTime;

	Image myImage;

	// Use this for initialization

	void Start()
	{

		myImage = GetComponent<Image>();

		gameObject.SetActive(true);
		myImage.CrossFadeAlpha(0f, fadeInTime, true);

	}

	// Update is called once per frame

	void Update()
	{

		if (Time.timeSinceLevelLoad >= fadeInTime)
		{
			Debug.Log("Faded in");
			gameObject.SetActive(false);

		}

	}
}
