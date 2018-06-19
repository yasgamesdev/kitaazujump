using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterText : MonoBehaviour
{
    Text centerText;
    // Use this for initialization
    void Start()
    {
        centerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetText(string text)
    {
        centerText.text = text;
    }
}
