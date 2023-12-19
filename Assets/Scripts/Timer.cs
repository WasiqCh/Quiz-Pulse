using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float timetoCompletion = 30f;
    [SerializeField] float timetoShowAnswer = 10f;
    public bool isAnsQuestions ;
    public bool loadNextQS;
    public float fillFraction;
    float timervalue;
    void Update()
    {
        updateTimer();
    }

    void updateTimer()
    {

        timervalue -= Time.deltaTime;
        if(isAnsQuestions)
        {
            if(timervalue > 0 )
            {
                fillFraction = timervalue / timetoCompletion;
            }
            else
            {
                isAnsQuestions = false;
                timervalue = timetoShowAnswer;
            }
        }
        else
        {
            if(timervalue>0){
                fillFraction = timervalue / timetoShowAnswer;
            }
            else
            {
                isAnsQuestions = true;
                timervalue = timetoCompletion;
                loadNextQS = true;
            }
        }
    }
    public void cancelTimer(){
        timervalue = 0;
    }
}
