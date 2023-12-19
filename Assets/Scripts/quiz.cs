using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO>  questions = new List<QuestionSO>();
    [SerializeField] QuestionSO currentQuestion;
    [Header("Answers")]
    [SerializeField] GameObject[] answerbutton;
    int corrAnsIndex;
    bool hasansweredearly;
    [Header("Buttons")]
    [SerializeField] Sprite defAnsSprite;
    [SerializeField] Sprite corrAnsSprite;
    [Header("Timer")]
    [SerializeField] Image timerimage;
    Timer timer;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreCounter scoreCounter;
    [Header("Slider")]
    [SerializeField] Slider progressBar;

    public bool isComplete;
    [System.Obsolete]
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreCounter = FindObjectOfType<ScoreCounter>();
        progressBar.value = 0;
        progressBar.maxValue = questions.Count;
    }
    void Update()
    {
        timerimage.fillAmount = timer.fillFraction;
        if(timer.loadNextQS)
        {
            hasansweredearly = false;
            getNextQuestion();
            timer.loadNextQS = false;
        }
        else if(!hasansweredearly && !timer.isAnsQuestions)
        {
            displayAnswer(-1);
            setButtonState(false);
        }
    }
    public void onAnsSelected(int index)
    {
        hasansweredearly = true;
        displayAnswer(index);
        setButtonState(false);
        timer.cancelTimer();
        scoreText.text = "Score: " + scoreCounter.calculateScore();
        if(progressBar.value == progressBar.maxValue){
            isComplete = true;
        }
    }
    void displayAnswer(int index)
    {
        if(index == currentQuestion.getcorrAnsIndex())
        {
            questionText.text = "Correct";
            Image buttonImage = answerbutton[index].GetComponent<Image>();
            buttonImage.sprite = corrAnsSprite;
            scoreCounter.IncrementCorrectAnswers();
        }
        else
        {
            corrAnsIndex = currentQuestion.getcorrAnsIndex();
            string correctAnswer = currentQuestion.GetAnswer(corrAnsIndex);
            questionText.text = "Sorry the Correct Answer was : \n" + correctAnswer;
            Image buttonImage = answerbutton[corrAnsIndex].GetComponent<Image>();
            buttonImage.sprite = corrAnsSprite;
        }
    }
    void getNextQuestion(){
        if(questions.Count>0)
        {
            setButtonState(true);
            setDefButtonSprites();
            GetRandomQuestions();
            displayQuestion();
            progressBar.value++;
            scoreCounter.IncrementQuestionsSeen();
        }
    }
    void GetRandomQuestions()
    {
        int index = Random.Range(0,questions.Count);
        currentQuestion = questions[index];
        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    private void setDefButtonSprites()
    {
        for(int i = 0 ; i < answerbutton.Length ; i++)
        {
            Image buttonImage = answerbutton[i].GetComponent<Image>();
            buttonImage.sprite = defAnsSprite;
        }
    }

    void displayQuestion(){
        questionText.text = currentQuestion.GetQuestion();
        for(int i=0 ; i<answerbutton.Length; i++)
        {
            TextMeshProUGUI buttonText = answerbutton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }
    void setButtonState(bool state){
        for(int i=0; i<answerbutton.Length;i++){
            Button button = answerbutton[i].GetComponent<Button>();
            button.interactable=state;
        }
    }
}
