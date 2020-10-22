using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update

    Button btn;
    EnemySpawner enemySpawner;
    TextMeshProUGUI textMesh;

    float spawnDelay = 2.5f;
    int level = 2;

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(NewRound);
        enemySpawner = FindObjectOfType<EnemySpawner>();
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void NewRound()
    {   
        StartCoroutine(enemySpawner.SpawnEnemies(level, spawnDelay));
        spawnDelay -= .5f;
        level++;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawner.levelComplete && FindObjectsOfType<EnemyHitDetector>().Length == 0)
        {
            textMesh.enabled = true;
        } else
        {
            textMesh.enabled = false;
        }

    }
}
