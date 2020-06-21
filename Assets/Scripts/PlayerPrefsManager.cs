using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MUSIC_VOLUME_KEY = "MUSIC_VOLUME";
    const string SOUND_VOLUME_KEY = "SOUND_VOLUME";
    const string VIBRATION_KEY = "VIBRATION";
    const string LEVEL_KEY = "LEVEL_NUMBER";
    const string TUTORIAL_PART1 = "TUTORIAL_PART1";
    const string TUTORIAL_PART2 = "TUTORIAL_PART2";
    const string TUTORIAL_PART3 = "TUTORIAL_PART3";

    public static void SetMusicVolume(float value)
	{
		if(value >= 0f && value <=0.1f)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, value);
		    PlayerPrefs.Save();
        }
		
	}

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY,0.1f);
    }

	public static void SetSoundVolume(float value)
	{
		if(value >= 0f && value <=1f)
        {
            PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, value);
		    PlayerPrefs.Save();
        }
	}

    public static float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat(SOUND_VOLUME_KEY,1f);
    }

    public static void SetVibration(bool value)
    {
        PlayerPrefs.SetInt(VIBRATION_KEY, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static bool GetVibration()
    {
        int value = PlayerPrefs.GetInt(VIBRATION_KEY, 1);
        
        if(value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetLevelNo(int value)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, value);
        PlayerPrefs.Save();
    }

    public static int GetLevelNo()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY, 1);
    }

    public static void SetTutorial(bool value)
    {
        if(Game.currentLevelIndex == 1)
        {
            PlayerPrefs.SetInt(TUTORIAL_PART1, value ? 1 : 0);
        }
        else if(Game.currentLevelIndex == 2)
        {
            PlayerPrefs.SetInt(TUTORIAL_PART2, value ? 1 : 0);
        }
        else if(Game.currentLevelIndex == 3)
        {
            PlayerPrefs.SetInt(TUTORIAL_PART3, value ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    public static bool GetTutorial()
    {
        int value = 0;
        if(Game.currentLevelIndex == 1)
        {
            value = PlayerPrefs.GetInt(TUTORIAL_PART1, 1);
        }
        else if(Game.currentLevelIndex == 2)
        {
            value = PlayerPrefs.GetInt(TUTORIAL_PART2, 1);
        }
        else if(Game.currentLevelIndex == 3)
        {
            value = PlayerPrefs.GetInt(TUTORIAL_PART3, 1);
        }
        
        if(value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
