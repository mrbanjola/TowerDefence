using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour
{

    [SerializeField] public int levelToLoad;
    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(LoadLevel);
    }


    void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
