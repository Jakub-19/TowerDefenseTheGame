using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;
    public Text crystalsText;
    void Update()
    {
        moneyText.text = PlayerStats.Money.ToString();
        crystalsText.text = PlayerStats.Crystals.ToString();
    }
}
