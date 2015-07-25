using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {
    public bool ddoCountDown;
	// Use this for initialization

    void Start()
    {
        if (!ddoCountDown)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<GameManager>().StageStart();
        }
    }

	// Update is called once per frame
	void Update () {
	
	}

    public void CountDownVoice(int i) {
        SoundManager.Instance.PlayVoice(i);
    }
}
