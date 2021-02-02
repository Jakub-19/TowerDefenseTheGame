using UnityEngine;
using UnityEngine.UI;

public class LevelSuccess : MonoBehaviour
{
    public Color notEarnedColor;
    public Color earnedColor;
    public Image[] bar;
    public string level;
    void Start()
    {
        for(int i=0; i < PlayerPrefs.GetInt(level); i++)
        {
            bar[i].color = earnedColor;
        }
        for (int i = PlayerPrefs.GetInt(level);  i < 3; i++)
        {
            bar[i].color = notEarnedColor;
        }
    }
}
