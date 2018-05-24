using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrueAnswerButton : MonoBehaviour {

    public Button trueAnsButton;
    public GameMaster gameMaster;

	// Use this for initialization
	void Start () {
        Button btn = trueAnsButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        gameMaster.SubmitAnswer(true);
    }
}
