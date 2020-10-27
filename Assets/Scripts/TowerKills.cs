using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerKills : MonoBehaviour
{
    public UpgradeTowers upgradeTowers;
    TextMeshProUGUI killText;

    // Start is called before the first frame update
    void Start()
    {
        upgradeTowers = FindObjectOfType<UpgradeTowers>();
        killText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (upgradeTowers.towerToUpgrade != null)
        {
            UpdateText(upgradeTowers.towerToUpgrade.kills);
            print(upgradeTowers.towerToUpgrade.weaponDamage);
        }

    }

    public void UpdateText(int kills)
    {
        killText.text = string.Format("Kills: {0}", kills);
    }
}
