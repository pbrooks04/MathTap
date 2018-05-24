using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {

    public AudioSource successAudio;
    public AudioSource failAudio;
    public AudioSource timeUpAudio;

    public AudioClip successClip;
    public AudioClip failClip;
    public AudioClip timeUpClip;

    public Button muteButton;

    public Sprite audioOnImage;
    public Sprite audioOffImage;


    bool isMuted = false;

    // Use this for initialization
    void Start () {
        muteButton = muteButton.GetComponent<Button>();
        muteButton.onClick.AddListener(TaskOnClick);

        successAudio.clip = successClip;
        failAudio.clip = failClip;
        timeUpAudio.clip = timeUpClip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        isMuted = !isMuted;

        if (isMuted)
        {  // Mute Image
            muteButton.GetComponent<Image>().sprite = audioOffImage;
        } else
        { // Audio On Image
            muteButton.GetComponent<Image>().sprite = audioOnImage;
        }
    }

    public void PlaySuccessSound()
    {
        if (isMuted)
            return;
        successAudio.Play();
    }

    public void PlayFailSound()
    {
        if (isMuted)
            return;
        failAudio.Play();
    }

    public void PlayTimeUpSound()
    {
        if (isMuted)
            return;
        timeUpAudio.Play();
    }
}
