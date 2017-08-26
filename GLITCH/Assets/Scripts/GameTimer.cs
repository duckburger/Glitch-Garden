using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private GameObject winLabel;
	

	public int levelTime;


	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		winLabel = GameObject.Find("Win Label");
		winLabel.SetActive(false);
		slider.maxValue = levelTime;
	}
	

	// Update is called once per frame
	void Update () {
		slider.value += Time.deltaTime;

		if (slider.value == levelTime && !isEndOfLevel)
		{
			audioSource.Play();
			Invoke("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
			winLabel.SetActive(true);
		}
	}


	void LoadNextLevel ()
	{
		SceneManager.LoadScene("02_Level2");
	}
}
