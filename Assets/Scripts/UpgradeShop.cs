using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public string[] playerPrefs;
    public Text goldAmount;
    public Button[] upgradeButtons;
    public Color normalColor;
    public Color upgradedColor;
    
    int gold = 0;
    int upgradesAmount = 0;
    void Start()
    {
        upgradesAmount = PlayerPrefs.GetInt("UpgradesAmount");
        gold = PlayerPrefs.GetInt("level1Gold") + PlayerPrefs.GetInt("level2Gold") + PlayerPrefs.GetInt("level3Gold") - PlayerPrefs.GetInt("UpgradesAmount");
        goldAmount.text = gold.ToString();
        gold = 3;
        //PlayerPrefs Names!!!
        //PlayerPrefs.SetInt("MagicSpellBought", 1);
        //PlayerPrefs.SetInt("MoreMineSpeedBought", 1);

        //PlayerPrefs.SetInt("AdditionalGoldBought", 1);
        //PlayerPrefs.SetInt("MagicSpellBought", 1);
        //PlayerPrefs.SetInt("MoreMineSpeedBought", 1);

        //PlayerPrefs.SetInt("AdditionalGoldBought", 1);
        //PlayerPrefs.SetInt("MagicSpellBought", 1);
        //PlayerPrefs.SetInt("MoreMineSpeedBought", 1);

        //PlayerPrefs.SetInt("AdditionalGold", 1);
        //PlayerPrefs.SetInt("MagicSpell", 1);
        //PlayerPrefs.SetFloat("MoreMineSpeed", 1.1f);

        //PlayerPrefs.SetFloat("BallistaMoreDamage", 1.1f);
        //PlayerPrefs.SetFloat("CannonMoreDamage", 1.1f);
        //PlayerPrefs.SetFloat("MageMoreDamage", 1.1f);

        //PlayerPrefs.SetFloat("BallistaMoreRange", 1.1f);
        //PlayerPrefs.SetFloat("CannonMoreRange", 1.1f);
        //PlayerPrefs.SetFloat("MageMoreRange", 1.1f);

        //PlayerPrefs.SetFloat("BallistaMoreFireRate", 1.1f);
        //PlayerPrefs.SetFloat("CannonMoreFireRate", 1.1f);
        //PlayerPrefs.SetFloat("MageMoreSlow", 1.1f);
        //PlayerPrefs.SetInt("AdditionalGoldBought", 0);

        UpdateView();

    }

    void UpdateView()
    {
        goldAmount.text = gold.ToString();
        int i = 0;
        foreach (string playerPref in playerPrefs)
        {
            if (PlayerPrefs.GetInt(playerPref + "Bought") == 1)
            {
                upgradeButtons[i].enabled = false;
                upgradeButtons[i].GetComponent<Image>().color = upgradedColor;
            }
            else
            {
                upgradeButtons[i].enabled = true;
                upgradeButtons[i].GetComponent<Image>().color = normalColor;
            }
            i++;
        }    
    }
    public void SetGoldUI()
    {
        goldAmount.text = gold.ToString();
    }
    public void ResetUpgrades()
    {
        gold = PlayerPrefs.GetInt("level1Gold") + PlayerPrefs.GetInt("level2Gold") + PlayerPrefs.GetInt("level3Gold");
        PlayerPrefs.SetInt("UpgradesAmount", 0);
        upgradesAmount = 0;

        foreach(string playerPref in playerPrefs)
        {
            PlayerPrefs.SetInt(playerPref + "Bought", 0);
        }
        UpdateView();

    }
    public void UpgradeInt(string playerPref)
    {
        if(CanAfford())
        {
            PlayerPrefs.SetInt(playerPref, 1);
            gold--;
            upgradesAmount++;
            PlayerPrefs.SetInt("UpgradesAmount", upgradesAmount);
            PlayerPrefs.SetInt(playerPref + "Bought", 1);
            UpdateView();
        }     
    }
    public void UpgradeFloat(string playerPref)
    {
        if (CanAfford())
        {
            PlayerPrefs.SetFloat(playerPref, 1.1f);
            gold--;
            upgradesAmount++;
            PlayerPrefs.SetInt("UpgradesAmount", upgradesAmount);
            PlayerPrefs.SetInt(playerPref + "Bought", 1);
            UpdateView();
        }
    }
    private bool CanAfford()
    {
        if (gold > 0)
            return true;
        else
            return false;
    }
}
