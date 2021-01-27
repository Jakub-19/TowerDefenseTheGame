using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;
    public GameObject gameOverUI;

    void OnEnable()
    {
        if(gameOverUI.activeSelf)
            roundsText.text = (PlayerStats.Rounds - 1).ToString();
        else
            roundsText.text = PlayerStats.Rounds.ToString();
    }

}
