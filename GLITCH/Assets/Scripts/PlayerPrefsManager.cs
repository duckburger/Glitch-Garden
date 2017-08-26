using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	// Things we are going to control (KEYS)

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";     // level_unlocked_1,2,3 etc (example of use)

	public static void SetMasterVolume (float volume)
	{
		if (volume >= 0f && volume <= 1f)
		{
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);

		} else
		{
			Debug.LogError("Volume is outside of 0-1 value");
		}
	}

	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1)
		{
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true, if you pass in the level number + 1 it means the level will be unlocked
		} else
		{
			Debug.LogError("Trying to unlock level not in build order");
		}
	}

	public static bool IsLevelUnlocked (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1)
		{
			if (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1)
			{
				return true;
			} else
			{
				return false;
			}
		}
		else
		{
			Debug.LogError("Level is outside of the build order");
			return false;
		}
	}


	public static void SetDifficulty (float difficulty)
	{
		if (difficulty > 0f && difficulty <= 3f)
		{
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else
		{
			Debug.LogError("Difficulty out of range!");
		}
	}

	public static float GetDifficulty ()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);

	}
}
