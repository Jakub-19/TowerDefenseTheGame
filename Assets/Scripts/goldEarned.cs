using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldEarned : MonoBehaviour
{
    public Text goldEarnedText;

    void OnEnable()
    {
        goldEarnedText.text = PlayerStats.Lives.ToString();
    }
}