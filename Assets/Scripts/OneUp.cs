using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.5f / GameObject.Find("Rope").GetComponent<Rope>().speed);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime);
	}
}
