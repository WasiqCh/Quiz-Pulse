using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    quiz quiz1;
    EndScreen endScreen;

    [System.Obsolete]
    void Awake()
    {
        quiz1 = FindObjectOfType<quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }
    void Start()
    {
        quiz1.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }
    void Update()
    {
        if(quiz1.isComplete){
            quiz1.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.showFinalScore();
        }
    }
    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
