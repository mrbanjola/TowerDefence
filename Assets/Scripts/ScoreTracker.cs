using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public int score = 0;

    TextMeshProUGUI scoreText;


    void Start()
    {

        scoreText = GetComponent<TextMeshProUGUI>();

    }

    public void UpdateScore()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }
}
