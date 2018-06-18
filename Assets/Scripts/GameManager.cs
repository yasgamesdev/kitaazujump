using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state { get; private set; } = GameState.Start;

    public Kitaazuchan kitaazuchan;
    public Rope rope;

    float buttonDownTime = 0.0f;
    // Use this for initialization
    void Start()
    {
        state = GameState.Play;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.Play && Input.GetMouseButton(0))
        {
            buttonDownTime += Time.deltaTime;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            kitaazuchan.Jump(buttonDownTime);
            buttonDownTime = 0.0f;
        }
    }
}

public enum GameState
{
    Start,
    Play,
    End
}