using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelector : MonoBehaviour
{
    Button btn;
    TowerFactory towerFactory;

    [SerializeField] Tower currentPrefab;


    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(selectTower);

        towerFactory = FindObjectOfType<TowerFactory>();
    }

    void selectTower()
    {
        towerFactory.towerPrefab = currentPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
