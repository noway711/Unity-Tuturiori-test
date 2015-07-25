using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private UnityChanControlScriptWithRgidBody unitychanScript;
    private TimerManager timerScript;
    private GameObject retryButton;
	// Use this for initialization
    void Awake()
    {
        unitychanScript = GameObject.Find("unitychan").GetComponent<UnityChanControlScriptWithRgidBody>();
        timerScript = GetComponent<TimerManager>();
        retryButton = GameObject.Find("RetryButton");
    }

	void Start () {
        SoundManager.Instance.ChangeBGMPitch(0, 1.0f);
        SoundManager.Instance.ChangeBGMVolume(0.5f);
        retryButton.SetActive(false);
        SoundManager.Instance.PlayBGM(0);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void StageStart()
    {
        unitychanScript.Controlable(true);
        timerScript.StartTimer();
    }
    
    public void StageFinish(int i) {
        SoundManager.Instance.ChangeBGMVolume(0.2f);
        timerScript.StopTimer();
        unitychanScript.StageFinish(i);
    }

    public void ShowRetryButton()
    {
        retryButton.SetActive(true);
    }

    public void DoRetry()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
