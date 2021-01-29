using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsInitializer : MonoBehaviour
{
    public string[] playerPrefsFloats;
    void Start()
    {
        foreach (string playerPref in playerPrefsFloats)
        {
            if (PlayerPrefs.GetFloat(playerPref) != 1 && PlayerPrefs.GetFloat(playerPref) != 1.1)
            {
                PlayerPrefs.SetFloat(playerPref, 1);
            }
        }
    }
}
