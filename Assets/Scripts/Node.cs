using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    public bool isMineNode = false;

    BuildManager buildManager;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        if (isMineNode)
        {
            if (buildManager.GetTurretToBuild().isMine)
                BuildTurret(buildManager.GetTurretToBuild());
            else
                return;
        }
        else
        {
            if (!buildManager.GetTurretToBuild().isMine)
                BuildTurret(buildManager.GetTurretToBuild());
            else
                return;
        } 
    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.moneyCost || PlayerStats.Crystals < blueprint.crystalCost)
        {
            Debug.Log("Not enough money or crystals to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.moneyCost;
        PlayerStats.Crystals -= blueprint.crystalCost;


        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret built!");
    }


    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeMoneyCost || PlayerStats.Crystals < turretBlueprint.upgradeCrystalCost)
        {
            Debug.Log("Not enough money or crystals to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeMoneyCost;
        PlayerStats.Crystals -= turretBlueprint.upgradeCrystalCost;

        //Get rid of the old turret
        Destroy(turret);

        //building a new one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret ()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret); 
        isUpgraded = false;
        turretBlueprint = null;
    }

    void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(isMineNode)
        {
            if (buildManager.GetTurretToBuild().isMine)
            {
                if (buildManager.HasMoney && buildManager.HasCrystals)
                    rend.material.color = hoverColor;
                else
                    rend.material.color = notEnoughMoneyColor;
            }
            else
                rend.material.color = notEnoughMoneyColor;
        }
        else
        {
            if (!buildManager.GetTurretToBuild().isMine)
            {
                if (buildManager.HasMoney && buildManager.HasCrystals)
                    rend.material.color = hoverColor;
                else
                    rend.material.color = notEnoughMoneyColor;
            }
            else
                rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
