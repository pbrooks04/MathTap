using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    GameObject startPanel;

    // Use this for initialization
    public Button startButton;
    public QuestionMaster questionMaster;
    public GameMaster gameMaster;

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        startPanel = GameObject.Find("StartPanel");
        
        questionMaster.CreateQuestion(0);
    }

    void TaskOnClick()
    {
        startPanel.SetActive(false);

        gameMaster.StartNewGame();
    }
}
