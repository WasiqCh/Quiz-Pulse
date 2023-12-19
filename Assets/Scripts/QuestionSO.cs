using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question" , fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string Question = "Enter new Question Text here:";
    [SerializeField ]string[] answers = new string[4];
    [SerializeField] int corrAnsIndex;

    public string GetQuestion(){
        return Question;
    }
    public string GetAnswer(int index){
        return answers[index];
    }
    public int getcorrAnsIndex(){
        return corrAnsIndex;
    }
}
