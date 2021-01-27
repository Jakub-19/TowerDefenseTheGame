using UnityEngine;

public class Mine : MonoBehaviour
{
    public int crystalGainPerCall;
    public float callingRate;

    void Start()
    {
        InvokeRepeating("GetCrystals", 0f, callingRate);
    }
    void GetCrystals()
    {
        PlayerStats.Crystals += crystalGainPerCall;
    }
}
