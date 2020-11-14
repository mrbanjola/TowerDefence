using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 100;

    [SerializeField] public TextMeshProUGUI textmesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        print("Ooops");
        // Handheld.Vibrate(); Only for mobile version
        playerHealth -= 10;
        textmesh.text = string.Format("x {0}", playerHealth);
    }
}   
