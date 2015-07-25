using UnityEngine;
using System.Collections;

public class CountDownScript : MonoBehaviour {
    public bool doCountDown = true;
	// Use this for initialization

    void Start()
    {
        if (!doCountDown)
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
