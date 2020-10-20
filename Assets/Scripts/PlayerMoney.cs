using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    MoneyTracker moneyTracker;

    public int playerMoney = 450;

    // Start is called before the first frame update

    private void Awake()
    {
        moneyTracker = FindObjectOfType<MoneyTracker>();
    }

    void Start()
    {

        moneyTracker.UpdateMoney(playerMoney);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
