using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
    public float rotateSpeed = 1f;
    private Animator animator;
    private BoxCollider boxCollider;
    private CountCoins countCoinsScript;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        countCoinsScript = GameObject.Find("GameManager").GetComponent<CountCoins>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed * 360f);
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySE(0);
            rotateSpeed *= 4.0f;
            animator.SetBool("coll", true);
            countCoinsScript.DecreaseCoinNum();            
            boxCollider.enabled = false;
        }
    }

    public void DestroyCoin()
    {
        Destroy(transform.parent.gameObject);
    }
}
