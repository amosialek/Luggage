using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public GameObject counterText;

    public void Awake()
    {
        counterText.GetComponent<Text>().text = "Score: " + counter.ToString();
    }

    private int counter = 3;
    public int Counter
    {
        get => counter;
        set
        {
            counter = value;
            counterText.GetComponent<Text>().text = "Score: " + counter.ToString();
        }
    }
}
