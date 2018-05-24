using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FalseAnswerButton : MonoBehaviour {

    public Button falseAnsButton;
    public GameMaster gameMaster;

    // Use this for initialization
    void Start()
    {
        Button btn = falseAnsButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        gameMaster.SubmitAnswer(false);
    }
}
