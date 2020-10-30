using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponData : MonoBehaviour

{
    public int weaponDamage = 2;
    [SerializeField ]List<WeaponData> WeaponDatas = new List<WeaponData>();
    [SerializeField] public int upgradePrice = 100;
    [SerializeField] public int increasePerUpgrade = 100;
    public int kills = 0;
    UpgradeTowers upgradeTowers;


    // Start is called before the first frame update
    void Start()
    {
        upgradeTowers = FindObjectOfType<UpgradeTowers>();
       
    }

    public void UpdateDamage()
    {
        foreach (WeaponData data in WeaponDatas)
        {
            data.weaponDamage++;
            
        }
       
       
    }
}
