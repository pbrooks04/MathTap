using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    int questionsAnswered = 0;
    int highScore = 0;
    public QuestionMaster questionMaster;
    public Slider timeSlider;
    public SoundButton soundMaster;

    public Text gameOverExplainationText;
    public Text newScoreText;
    public Text bestScoreText;

    GameObject gamePanel;
    GameObject startPanel;
    GameObject gameOverPanel;

    private Animator gameOverPanelAnimator;
    private Animator gamePanelAnimator;

    public Text scoreUIText;

    const float MAX_ANSWER_TIME = 1.0f;
    float answerTime = 1.0f;

    bool gameIsOver = false;

    // Use this for initialization
    void Start() {
        startPanel = GameObject.Find("StartPanel");
        gamePanel = GameObject.Find("GamePanel");
        gameOverPanel = GameObject.Find("GameOverPanel");

        gameOverPanelAnimator = gameOverPanel.GetComponent<Animator>();
        gamePanelAnimator = gamePanel.GetComponent<Animator>();

        startPanel.SetActive(true);
        highScore = PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update() {
        if (questionsAnswered > 0 && !gameIsOver)
        {
            if (answerTime > 0)
            {
                answerTime -= Time.deltaTime;
                timeSlider.value = answerTime / MAX_ANSWER_TIME; // Value is from 0 to 1
            }
            else
            {
                EndGame(true);
            }
        }

        if ( !startPanel.activeSelf && gameOverPanelAnimator.GetInteger("SlideDirection") > 0 && !gamePanelAnimator.GetBool("Appear") )
        {
            gamePanelAnimator.SetBool("Appear", true);
        }
    }

    public void SubmitAnswer(bool answer)
    {
        if (answerTime < 0 || gameIsOver)
        {
            return;
        }
        bool currentAnswerIsCorrect = questionMaster.CurrentAnswerIsCorrect();

        if (answer == currentAnswerIsCorrect)
        {   // Success
            questionsAnswered++;
            answerTime = MAX_ANSWER_TIME;
            questionMaster.CreateQuestion(questionsAnswered);

            // Start Timer
            answerTime = MAX_ANSWER_TIME;
            soundMaster.PlaySuccessSound();
          
        } else
        {   // Failure
            soundMaster.PlayFailSound();
            gamePanelAnimator.SetBool("IncorrectAnswer", true);
            
            EndGame(false);
            
        }

        scoreUIText.text = questionsAnswered.ToString();
    }

    void EndGame(bool isTimeOutLoss)
    {
        gamePanelAnimator.SetBool("Appear", false);
        gameOverPanelAnimator.SetInteger("SlideDirection", -1);

        gameIsOver = true;
        if (questionsAnswered > highScore)
        {
            highScore = questionsAnswered;
            PlayerPrefs.SetInt("highScore", highScore);
        }


        // Display game over screen
        if (isTimeOutLoss)
        {
            gameOverExplainationText.text = "Time's up!";
            soundMaster.PlayTimeUpSound();
        }
        else
        {
            gameOverExplainationText.text = "Incorrect Answer";
        }


        newScoreText.text = questionsAnswered.ToString();
        bestScoreText.text = highScore.ToString();
    }

    public void StartNewGame()
    {
        questionsAnswered = 0;
        scoreUIText.text = questionsAnswered.ToString();
        questionMaster.CreateQuestion(questionsAnswered);

        gamePanelAnimator.SetBool("IncorrectAnswer", false);
        gamePanelAnimator.SetBool("Appear", true);
        
        int slideDirection = gameOverPanelAnimator.GetInteger("SlideDirection");
        
        if (slideDirection < 0)
        {
            gameOverPanelAnimator.SetInteger("SlideDirection", 1);
        }

        answerTime = MAX_ANSWER_TIME;

        timeSlider.value = answerTime / MAX_ANSWER_TIME;
        gameIsOver = false;
    }
}
