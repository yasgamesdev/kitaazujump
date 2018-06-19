using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Kitaazuchan kitaazuchan;
    AudioSource audioSource;

    public bool isRotate = false;
    public float speed = 1.0f;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
                audioSource.Play();

                CheckCollision();
            }
        }
    }

    void CheckCollision()
    {
        if(kitaazuchan.IsGround())
        {
            Debug.Log("Fault");
        }
    }
}
