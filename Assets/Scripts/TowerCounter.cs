using UnityEngine;
using TMPro;

public class TowerCounter : MonoBehaviour
{
    TextMeshProUGUI countText;

    public TowerFactory towerFactory;

    public int towerCount;
    public int maxTowers;


    void Start()
    {
        countText = GetComponent<TextMeshProUGUI>();
        towerFactory = FindObjectOfType<TowerFactory>();
    }



    public void updateCount()
    {
        towerCount = FindObjectsOfType<Tower>().Length;
        maxTowers = towerFactory.towerLimit;
        countText.text = string.Format("Towers: {0}/{1}",towerCount,maxTowers);


    }


    

    void Update()
    {
        
    }
}
