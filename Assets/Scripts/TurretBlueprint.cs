using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int moneyCost;
    public int crystalCost;

    public GameObject upgradedPrefab;
    public int upgradeMoneyCost;
    public int upgradeCrystalCost;

    public bool isMine = false;
    public int GetSellAmount()
    {
        return moneyCost / 2;
    }

}
