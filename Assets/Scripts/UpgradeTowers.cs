using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeTowers : MonoBehaviour
{
    public int damage = 1;
    Button btn;

    PlayerMoney playerMoney;
    MoneyTracker moneyTracker;
    int upgradePrice = 400;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = FindObjectOfType<PlayerMoney>();
        moneyTracker = FindObjectOfType<MoneyTracker>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(IncreaseDamage);
        
    }

    void IncreaseDamage()
    {
        if (playerMoney.playerMoney >= upgradePrice)
        {
            damage++;
            playerMoney.playerMoney -= upgradePrice;
            moneyTracker.UpdateMoney(playerMoney.playerMoney);
            upgradePrice += 300;
            UpdateText();
        }
       
    }

    void UpdateText()
    {
        GetComponent<TextMeshProUGUI>().text = string.Format("Upgrade towers (${0})",upgradePrice);
    }


    // Update is called once per frame
    void Update()
    {

        if (playerMoney.playerMoney < upgradePrice)
        {
            GetComponent<TextMeshProUGUI>().color = Color.red;
        } else
        {
            GetComponent<TextMeshProUGUI>().color = Color.white;
        }


    }
}
