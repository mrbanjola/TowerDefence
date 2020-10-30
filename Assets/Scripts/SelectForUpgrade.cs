using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectForUpgrade : MonoBehaviour
{
    public UpgradeTowers upgradeTowers;
    public TextMeshProUGUI upgradeText;
    public CurrentDamage currentDamageText;
    
    


    void Start()
    {
        upgradeTowers = FindObjectOfType<UpgradeTowers>();
        upgradeText = FindObjectOfType<UpgradeTowers>().GetComponentInParent<TextMeshProUGUI>();
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            upgradeTowers.towerToUpgrade = gameObject.GetComponentInChildren<WeaponData>();
            upgradeText.enabled = true;
            upgradeTowers.UpdateText(gameObject.GetComponentInChildren<WeaponData>().upgradePrice);
            
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
