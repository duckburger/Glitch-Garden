using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;


	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
		
	}

	void OnEnable()
	{
		//Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
	
	private void OnLevelFinishedLoading(Scene arg0, LoadSceneMode arg1)
	{
		int audioClipForThisLevel = SceneManager.GetActiveScene().buildIndex;

		audioSource = GetComponent<AudioSource>();
		audioSource.clip = levelMusicChangeArray[audioClipForThisLevel];
		audioSource.loop = true;
		audioSource.Play();

		

	}

	internal void ChangeVolume(float volume)
	{
		audioSource.volume = volume;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChooseAndPlayMusic()
	{

	}

	
}
