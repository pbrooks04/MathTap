using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour {

    GameObject startPanel;

    public Button homeButton;



    private Animator gameOverPanelAnimator;

    // Use this for initialization
    void Start () {
        startPanel = GameObject.Find("StartPanel");

        gameOverPanelAnimator = GameObject.Find("GameOverPanel").GetComponent<Animator>();

        Button btn = homeButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        startPanel.SetActive(true);
        gameOverPanelAnimator.SetInteger("SlideDirection", 1);
    }
}
