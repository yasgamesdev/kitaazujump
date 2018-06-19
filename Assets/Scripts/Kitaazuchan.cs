using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitaazuchan : MonoBehaviour {
    Rigidbody rigid;
    public Rope rope;
    public AudioSource jumpAudioSource, oneupAudioSource;
    public float force;

    public Transform oneUpPos;
    public GameObject oneUpPrefab;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Jump(float buttonDownTime)
    {
        rigid.AddForce(new Vector3(0.0f, force * buttonDownTime, 0.0f));
        if(rope.score < Rope.oneupScore)
        {
            jumpAudioSource.Play();
        }
        else
        {
            oneupAudioSource.Play();
            Instantiate(oneUpPrefab, oneUpPos.position, oneUpPos.rotation);
        }
    }

    public bool IsGround()
    {
        return Physics.Raycast(transform.position + new Vector3(0.0f, -0.95f, 0.0f), -Vector3.up, 0.1f);
    }
}
