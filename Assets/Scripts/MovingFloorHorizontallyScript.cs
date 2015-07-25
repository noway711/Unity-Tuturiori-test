using UnityEngine;
using System.Collections;

public class MovingFloorHorizontallyScript : MonoBehaviour {
    Vector3 velocity, prePos;
	// Use this for initialization
	void Start () {
        prePos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        velocity = (transform.position - prePos) / Time.deltaTime;
        prePos = transform.position;
	}
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.transform.parent = null;
            coll.gameObject.GetComponent<Rigidbody>().velocity = velocity;
        }
    }
    
}
