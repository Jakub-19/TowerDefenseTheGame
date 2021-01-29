using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{


    public string menuSceneName = "MainMenu";

    public string levelSelect = "LevelSelect";
    public int levelToUnlock = 2;
    public int levelNumber = 1;

    public SceneFader sceneFader;
    

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        int gold = PlayerStats.Lives;
        if (levelNumber == 1)
        {
            if(PlayerPrefs.GetInt("level1Gold") < gold)
                PlayerPrefs.SetInt("level1Gold", gold);
        }  
        else if(levelNumber == 2)
        {
            if (PlayerPrefs.GetInt("level2Gold") < gold)
                PlayerPrefs.SetInt("level2Gold", gold);
        }
        else if (levelNumber == 3)
        {
            if (PlayerPrefs.GetInt("level3Gold") < gold)
                PlayerPrefs.SetInt("level3Gold", gold);
        }

        sceneFader.FadeTo(levelSelect);
    }
    public void Menu()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        int gold = PlayerStats.Lives;
        if (levelNumber == 1)
        {
            if (PlayerPrefs.GetInt("level1Gold") < gold)
                PlayerPrefs.SetInt("level1Gold", gold);
        }
        else if (levelNumber == 2)
        {
            if (PlayerPrefs.GetInt("level2Gold") < gold)
                PlayerPrefs.SetInt("level2Gold", gold);
        }
        else if (levelNumber == 3)
        {
            if (PlayerPrefs.GetInt("level3Gold") < gold)
                PlayerPrefs.SetInt("level3Gold", gold);
        }
        sceneFader.FadeTo(menuSceneName);
    }
    
}
