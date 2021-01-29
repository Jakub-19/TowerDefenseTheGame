using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public string levelToLoadS = "Shop";
    public string levelToLoadL = "LevelSelect";

    public Button[] levelButtons;
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if( i+1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
    public void GoToShop()
    {
        fader.FadeTo(levelToLoadS);
    }
    public void GoToLevelSelect()
    {
        fader.FadeTo(levelToLoadL);
    }
    public void GoToMenu()
    {
        fader.FadeTo("MainMenu");
    }
}
