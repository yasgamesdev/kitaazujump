﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    public const int oneupScore = 50;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //isRotate = true;
    }

    // Update is called once per frame
    async Task Update()
    {
        if(isRotate)
        {
            float oldRotationX = transform.rotation.x;

            transform.Rotate(new Vector3(360.0f * Time.deltaTime * speed, 0.0f, 0.0f));

            if(transform.rotation.x * oldRotationX < 0)
            {
                await CheckCollision();
            }
        }
        speed += 0.0002f;
    }

    async Task CheckCollision()
    {
        if(kitaazuchan.IsGround())
        {
            await manager.GameOver();
        }
        else
        {
            score++;
            scoreText.text = string.Format("{0:D4}", score);
            if(score >= oneupScore)
            {
                scoreText.color = Color.green;
            }

            audioSource.Play();
        }
    }
}
