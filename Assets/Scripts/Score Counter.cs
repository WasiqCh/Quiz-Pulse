using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    int correctAnswers = 0;
    int questionsSeen = 0 ;
    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }
    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }
    public int GetQuestionsSeen()
    {
        return questionsSeen;
    }
    public void IncrementQuestionsSeen(){
        questionsSeen++;
    }
    public int calculateScore(){
        return correctAnswers;
    }
}
