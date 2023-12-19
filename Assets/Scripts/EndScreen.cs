using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreCounter scoreCounter;

    [System.Obsolete]
    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }
    public void showFinalScore()
    {
        finalScoreText.text = "Congratulations!\n\tYou Scored: " 
                                + scoreCounter.calculateScore();
    }
}
