using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public int score = 0;

    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {

        scoreText = GetComponent<TextMeshProUGUI>();

    }

    public void UpdateScore()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
