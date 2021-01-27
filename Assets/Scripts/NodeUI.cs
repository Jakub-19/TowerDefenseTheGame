using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Text upgradeCrystalCost;
    public GameObject upgradeDone;
    public GameObject costs;
    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        

        if (!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeMoneyCost.ToString();
            upgradeCrystalCost.text = target.turretBlueprint.upgradeCrystalCost.ToString();
            costs.SetActive(true);
            upgradeButton.interactable = true;
            upgradeDone.SetActive(false);
        }
        else
        {
            upgradeDone.SetActive(true);
            costs.SetActive(false);
            upgradeButton.interactable = false;
        }

        sellAmount.text = target.turretBlueprint.GetSellAmount().ToString();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }


    public void Upgrade ()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
