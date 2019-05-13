using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public GameObject counterText;
    public static bool spawned = false;
    private static int counter = 3;
    public void Refresh()
    {
        counterText.GetComponent<Text>().text = "Lives: " + counter.ToString();
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
}
