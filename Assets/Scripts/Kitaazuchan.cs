﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitaazuchan : MonoBehaviour {
    Rigidbody rigid;
    public float force;
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
    }

    public bool IsGround()
    {
        return Physics.Raycast(transform.position + new Vector3(0.0f, -0.95f, 0.0f), -Vector3.up, 0.1f);
    }
}