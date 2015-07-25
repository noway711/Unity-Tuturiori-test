using UnityEngine;
using System.Collections;

public class GoalCamera : MonoBehaviour {
    private Camera mainCamera;
    private Camera goalCamera;
    private Animator goalCameraAnimator;
    private Animator unitychanScript;
    private GameManager gameManagerScript;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        goalCamera = GetComponent<Camera>();
        goalCameraAnimator = gameObject.transform.parent.GetComponent<Animator>();
        unitychanScript = GameObject.Find("unitychan").GetComponent<Animator>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoalCameraMotion(int i)
    {
        goalCamera.enabled = true;
        mainCamera.enabled = false;
        Invoke("FinishCameraMotion", 2.0f);
        if (i == 0) goalCameraAnimator.SetBool("Goal", true);
        if (i == 1) goalCameraAnimator.SetBool("GameOver", true);
    }

    public void FinishCameraMotion()
    {
        gameManagerScript.ShowRetryButton();
    }
}
