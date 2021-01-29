using UnityEngine;

public class Mine : MonoBehaviour
{
    public int crystalGainPerCall;
    public float callingRate;

    void Start()
    {
        InvokeRepeating("GetCrystals", 0f, callingRate * (2- PlayerPrefs.GetFloat("MoreMineSpeed")));
    }
    void GetCrystals()
    {
        PlayerStats.Crystals += crystalGainPerCall;
    }
}
