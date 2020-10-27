using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentDamage : MonoBehaviour
{
    public UpgradeTowers upgradeTowers;
    TextMeshProUGUI damageText;

    // Start is called before the first frame update
    void Start()
    {
        upgradeTowers = FindObjectOfType<UpgradeTowers>();
        damageText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeTowers.towerToUpgrade != null)
        {
            UpdateText(upgradeTowers.towerToUpgrade.weaponDamage);
            print(upgradeTowers.towerToUpgrade.weaponDamage);
        }
        
    }

    public void UpdateText(int damage)
    {
        damageText.text = string.Format("Damage: {0}",damage);
    }
}
