using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour

{
    public int weaponDamage = 2;
    public int upgradePrice = 100;
    public int kills = 0;
    UpgradeTowers upgradeTowers;


    // Start is called before the first frame update
    void Start()
    {
        upgradeTowers = FindObjectOfType<UpgradeTowers>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void UpdateDamage()
    {
        weaponDamage++;
    }
}
