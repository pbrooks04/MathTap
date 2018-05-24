using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// Responsible for creating and displaying questions and answers
//   as well as being a reference for values
//
public class QuestionMaster : MonoBehaviour {

    bool currentAnswerIsCorrect;

    public Text questionUIText;
    public Text answerUIText;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    // Pick two random integers and decide to display correct answer or not
    //
    //     Set QUESTION and ANSWER text
    //
    public void CreateQuestion(int questionsAnswered)
    {
        // Get more difficult
        int maxValue = questionsAnswered + 7;
        // Pick two random integers between 0 & maxValue
        
        int ran1 = Mathf.FloorToInt(Random.value * maxValue);
        int ran2 = Mathf.FloorToInt(Random.value * maxValue);
        
        int solution = ran1 + ran2;
        bool displayCorrectAnswer = true;

        // 50% chance it will be 40-60 in favour of true or false
        // Why? Why not? I dunno
        displayCorrectAnswer = (Random.value < 0.5f) ? ( (Random.value < 0.6f) ? false : true ) : ( (Random.value < 0.4f ) ? false : true);

        string questionString = ran1.ToString() + " + " + ran2.ToString();
        string answerString = " = ";

        if (displayCorrectAnswer)
        {
            answerString += solution.ToString();
        }
        else
        {
            // Need to generate a false answer
            // Add 1 to 3
            int ranAddition = Mathf.FloorToInt(Random.value * 3) + 1;
            answerString += (solution + ranAddition).ToString();
        }

        currentAnswerIsCorrect = displayCorrectAnswer;
        questionUIText.text = questionString;
        answerUIText.text = answerString;
        
    }

    public bool CurrentAnswerIsCorrect()
    {
        return currentAnswerIsCorrect;
    }
}
