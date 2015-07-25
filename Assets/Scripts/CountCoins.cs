using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountCoins : MonoBehaviour {
    public Text counterText;
    private int coinNumAll;
    private int coinNum;
    private UnityChanControlScriptWithRgidBody unitychanScript;
    private GoalCamera goalCameraScript;

    private GameManager gameManagerScript;

	// Use this for initialization
	void Start () {
        coinNumAll = GameObject.FindGameObjectsWithTag("Coin").Length;
        coinNum = coinNumAll;

        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        unitychanScript = GameObject.Find("unitychan").GetComponent<UnityChanControlScriptWithRgidBody>();
        goalCameraScript = GameObject.Find("GoalCamera").GetComponent<GoalCamera>();
	}
	
	// Update is called once per frame
	void Update () {
        counterText.text = coinNum.ToString() + " / " + coinNumAll.ToString();
	}



    public void DecreaseCoinNum()
    {
        coinNum--;
        if (coinNum == 0)
        {
            gameManagerScript.StageFinish(0);
        }
    }
}
