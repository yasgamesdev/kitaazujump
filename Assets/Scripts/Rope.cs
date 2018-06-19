using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rope : MonoBehaviour
{
    public Kitaazuchan kitaazuchan;
    public GameManager manager;
    public Text scoreText;

    AudioSource audioSource;

    public bool isRotate = false;
    public float speed = 1.0f;
    public int score = 0;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //isRotate = true;
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
        speed += 0.0001f;
    }

    void CheckCollision()
    {
        if(kitaazuchan.IsGround())
        {
            manager.GameOver();
        }
        else
        {
            score++;
            scoreText.text = string.Format("{0:D4}", score);

            audioSource.Play();
        }
    }
}
