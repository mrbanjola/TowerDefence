using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeTowers : MonoBehaviour
{
    public int damage = 1;
    Button btn;

    public WeaponData towerToUpgrade;


    PlayerMoney playerMoney;
    MoneyTracker moneyTracker;
    CurrentDamage currentDamage;
    int upgradePrice = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = FindObjectOfType<PlayerMoney>();
        moneyTracker = FindObjectOfType<MoneyTracker>();
        btn = GetComponent<Button>();
        currentDamage = FindObjectOfType<CurrentDamage>();
        btn.onClick.AddListener(IncreaseDamage);
        UpdateText(100);
        
    }

    void IncreaseDamage()
    {
        if (playerMoney.playerMoney >= towerToUpgrade.upgradePrice)
        {
            
            towerToUpgrade.UpdateDamage();
            playerMoney.playerMoney -= upgradePrice;
            moneyTracker.UpdateMoney(playerMoney.playerMoney);
            towerToUpgrade.upgradePrice += 100;
            UpdateText(towerToUpgrade.upgradePrice);
            currentDamage.UpdateText(towerToUpgrade.weaponDamage);
        }
       
    }

    public void UpdateText(int price)
    {
        GetComponent<TextMeshProUGUI>().text = string.Format("Upgrade tower (${0})",price);
    }


    // Update is called once per frame
    void Update()
    {
        if (towerToUpgrade != null)
        {
            upgradePrice = towerToUpgrade.upgradePrice;
        } else
        {
            upgradePrice = 100;
        }

        if (playerMoney.playerMoney < upgradePrice)
        {
            GetComponent<TextMeshProUGUI>().color = Color.red;
        } else
        {
            GetComponent<TextMeshProUGUI>().color = Color.white;
        }

        


    }
}
