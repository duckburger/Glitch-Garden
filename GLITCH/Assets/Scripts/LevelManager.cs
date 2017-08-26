using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	

	void OnAwake ()
	{
		DontDestroyOnLoad(gameObject);
		
	}

	// Use this for initialization
	void Start () {


		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			if (autoLoadNextLevelAfter <= 0)
			{
				Debug.Log("Auto load disbaled, use a positive number in seconds");
			} else
			{
				int currentScene = SceneManager.GetActiveScene().buildIndex;
				Invoke("LoadNextLevel", autoLoadNextLevelAfter);
			}
			
		} else
		{
			Debug.Log("Not the splash screen, so won't delay the level load");
		}

		Debug.Log("Difficulty is set at " + PlayerPrefsManager.GetDifficulty());
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadNextLevel()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene + 1);
	}

	public void LoadPreviousLevel()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene - 1);
	}

	public void LoadLevelOne()
	{
		SceneManager.LoadScene(2);
	}

	public void ShowWinScreen()
	{
		SceneManager.LoadScene(5);
	}

	public void ShowLoseScreen()
	{
		SceneManager.LoadScene(4);
	}

	public void ShowOptionsScreen()
	{
		SceneManager.LoadScene(3);
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
