using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public bool isRotate = false;
    public float speed = 1.0f;
    // Use this for initialization
    void Start()
    {
        isRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotate)
        {
            float oldRotationX = transform.rotation.x;

            transform.Rotate(new Vector3(360.0f * Time.deltaTime * speed, 0.0f, 0.0f));

            if(transform.rotation.x * oldRotationX < 0)
            {
                CheckCollision();
            }
        }
    }

    void CheckCollision()
    {
        Debug.Log("Check");
    }
}
