using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        
    }

    public void OnTriggerEnter(Collider other)
    {
        print("Ooops");
        playerHealth -= 10;
        textmesh.text = string.Format("x {0}", playerHealth);
    }
}
