using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour {
    private Text timerText;
    public float timerMax;
    public int hurryupTime;
    private float timer;
    private bool timerEnabled = false;
    private GameManager gameManagerScript;
	// Use this for initialization
	void Start () {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        timer = timerMax;
	}
	
	// Update is called once per frame
	void Update () {
        timerText.text = Mathf.FloorToInt(timer).ToString() + " s";
        if (timerEnabled)
        {            
            timer -= Time.deltaTime;
            if (Mathf.FloorToInt(timer) <= hurryupTime)
            {
                timerText.color = new Color(0.9f, 0.0f, 0.0f);
                SoundManager.Instance.PlayVoice(6);
                SoundManager.Instance.ChangeBGMPitch(0, 1.2f);
                hurryupTime = -10;
            }
            

            if (timer < 0.0f)
            {
                StopTimer();
                gameManagerScript.StageFinish(1);
                timer = 0.0f;
            }
        }
	}

    public void StartTimer()
    {
        timerEnabled = true;
    }

    public void StopTimer()
    {
        timerEnabled = false;
    }
}
