using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MaxTowerText : MonoBehaviour
{
    TowerFactory towerFactory;
    PlayerMoney playerMoney;
    MoneyTracker moneyTracker;
    Button btn;
    int increasePrize = 300;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = FindObjectOfType<PlayerMoney>();
        towerFactory = FindObjectOfType<TowerFactory>();
        moneyTracker = FindObjectOfType<MoneyTracker>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(IncreaseTowers);
    }

    void IncreaseTowers()
    {
        if (playerMoney.playerMoney >= increasePrize)
        {
            towerFactory.towerLimit++;
            playerMoney.playerMoney -= increasePrize;
            moneyTracker.UpdateMoney(playerMoney.playerMoney);
            increasePrize += 100;
            gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("Increase max towers (${0})",increasePrize);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMoney.playerMoney < increasePrize)
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;
        } else
        {
            gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
        
    }
}
