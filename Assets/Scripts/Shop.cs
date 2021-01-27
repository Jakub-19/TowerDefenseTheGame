using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint mine;
    public Text ballistaCostGold;
    public Text ballistaCostCrystal;
    public Text canonCostGold;
    public Text canonCostCrystal;
    public Text mageCostGold;
    public Text mageCostCrystal;
    public Text mineCostGold;
    public Text mineCostCrystal;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

        ballistaCostGold.text = standardTurret.moneyCost.ToString();
        ballistaCostCrystal.text = standardTurret.crystalCost.ToString();

        canonCostGold.text = missileLauncher.moneyCost.ToString();
        canonCostCrystal.text = missileLauncher.crystalCost.ToString();

        mageCostGold.text = laserBeamer.moneyCost.ToString();
        mageCostCrystal.text = laserBeamer.crystalCost.ToString();

        mineCostGold.text = mine.moneyCost.ToString();
        mineCostCrystal.text = mine.crystalCost.ToString();
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }
    public void SelectMine()
    {
        buildManager.SelectTurretToBuild(mine);
    }
}
