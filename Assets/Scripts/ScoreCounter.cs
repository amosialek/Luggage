using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public GameObject counterText;

    private static int counter = 0;
    public void Refresh()
    {
        counterText.GetComponent<Text>().text = "Score: " + counter.ToString();
    }

    public int Counter
    {
        get => counter;
        set
        {
            counter = value;
            Refresh();
        }
    }

    internal void ChangeColor(Color color)
    {
        counterText.GetComponent<Text>().color = color;
    }

    public void Reset()
    {
        this.Counter = 0;
    }
}
