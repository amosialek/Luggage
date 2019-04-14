using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject LevelMenu;
    public GameObject MainMenu;
    public GameObject HelpMenu;
    public GameObject LevelButton;
    // Start is called before the first frame update
    public GameObject settingsButton;
    public int levelsAvailable;
    public List<GameObject> levelButtons;

    void Awake()
    {
        var button = LevelButton;
        {
            var level = button.AddComponent<Level>();
            level.sceneId = 1;
            button.GetComponent<Button>().onClick.AddListener(() => level.LoadScene());
        }
        float lastButtonRight = button.transform.position.x;
        float lastButtonTop = button.transform.position.y;
        levelButtons.Add(button);

        for (int i = 2; i <= levelsAvailable; i++)
        {
            var secondButton = GameObject.Instantiate(levelButtons.Last(), LevelMenu.transform);
            levelButtons.Add(secondButton);
            var rectT = secondButton.GetComponent<RectTransform>();
            //secondButton.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(lastButtonRight + 5, lastButtonTop), new Quaternion());
            secondButton.transform.position = new Vector3(lastButtonRight + 40, lastButtonTop);

            var level = secondButton.AddComponent<Level>();
            level.sceneId = i;
            secondButton.GetComponent<Button>().onClick.AddListener(() => level.LoadScene());
            var text = secondButton.GetComponentInChildren<Text>();
            text.text = i.ToString();
            lastButtonRight = secondButton.GetComponent<RectTransform>().rect.xMax;
        }
    }

    public void DisableAllMenus()
    {
        HelpMenu.SetActive(false);
        MainMenu.SetActive(false);
        LevelMenu.SetActive(false);
    }

    public void ShowHelpMenu()
    {
        DisableAllMenus();
        HelpMenu.SetActive(true);
    }

    public void ShowLevels()
    {
        DisableAllMenus();
        LevelMenu.SetActive(true);
    }
    [Serializable]
    public class Level :MonoBehaviour
    {
        public int sceneId;
        public Level(int id)
        {
            this.sceneId = id;
        }
        public bool Passed { get; set; }
        public int Stars { get; set; }

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneId);
        }

    }

    public void BackButton()
    {
        DisableAllMenus();
        MainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
