using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingsButton;
    public void Change()
    {
        
        settingsButton.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
