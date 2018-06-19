using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state { get; private set; } = GameState.Start;

    public Kitaazuchan kitaazuchan;
    public Rope rope;
    public CenterText centerText;

    AudioSource audioSource;

    float buttonDownTime = 0.0f;

    public const float maxForce = 1.0f;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //state = GameState.Play;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.Start && Input.GetMouseButtonUp(0))
        {
            rope.isRotate = true;
            centerText.SetText("");

            state = GameState.Play;
        }
        else if(state == GameState.Play && Input.GetMouseButton(0) && kitaazuchan.IsGround())
        {
            buttonDownTime += Time.deltaTime;
        }
        else if(state == GameState.Play && Input.GetMouseButtonUp(0) && kitaazuchan.IsGround())
        {
            kitaazuchan.Jump(GetForce());
            buttonDownTime = 0.0f;
        }
    }

    public float GetForce()
    {
        return Mathf.Min(maxForce, buttonDownTime);
    }

    public void GameOver()
    {
        rope.isRotate = false;
        centerText.SetText("GAME OVER");
        audioSource.Play();

        state = GameState.End;
    }
}

public enum GameState
{
    Start,
    Play,
    End
}