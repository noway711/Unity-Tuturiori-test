using UnityEngine;
using System.Collections;

public class GreenBoxScript : MonoBehaviour {
    public AudioClip crashSound;

    private AudioSource audioSource;
    private float preVelocity = 0.0f;
    private float velocity;
    private float acceleration;
    private float angularVelocity;
    private float preAngularVelocity;
    private float angularAcceleration;
    private float volume;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	
	void Update () {
        velocity = GetComponent<Rigidbody>().velocity.magnitude;
        angularVelocity = GetComponent<Rigidbody>().angularVelocity.magnitude;

        acceleration = (velocity - preVelocity) / Time.deltaTime;
        angularAcceleration = (angularVelocity - preAngularVelocity) / Time.deltaTime;

        if (acceleration > 200.0f || angularAcceleration > 200.0f)
        {
            audioSource.pitch = 1.0f + Random.Range(-0.2f, 0.2f);
            volume = Mathf.Lerp(0.2f, 0.5f, acceleration + angularVelocity);
            GetComponent<AudioSource>().PlayOneShot(crashSound, volume);
        }
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            audioSource.pitch = 1.0f + Random.Range(-0.2f, 0.2f);
            GetComponent<AudioSource>().PlayOneShot(crashSound, 0.8f);
        }
    }
}
