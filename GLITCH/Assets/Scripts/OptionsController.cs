﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();

	}
	
	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume(volumeSlider.value);
	}

	public void SetDefaultSettings()
	{
		volumeSlider.value = 0.5f;
		difficultySlider.value = 2f;
	}

	public void SaveAndExit ()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		SceneManager.LoadScene(1);
	}
}
