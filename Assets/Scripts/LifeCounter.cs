using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public GameObject counterText;

    public void Awake()
    {
        counterText.GetComponent<Text>().text = "Lives: " + counter.ToString();
    }

    private int counter = 3;
    public int Counter
    {
        get => counter;
        set
        {
            counter = value;
            counterText.GetComponent<Text>().text = "Lives: " + counter.ToString();
        }
    }
}
