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
    public GameObject LevelButton;
    // Start is called before the first frame update
    public GameObject settingsButton;
    public int levelsAvailable;
    public List<GameObject> levelButtons;

    void Awake()
    {
        var button = LevelButton;
        button.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(456.5f + 37 + 40, 225.5f), new Quaternion());
        {
            var level = button.AddComponent<Level>();
            level.sceneId = 1;
            button.GetComponent<Button>().onClick.AddListener(() => level.LoadScene());
        }

        levelButtons.Add(button);
        for (int i = 2; i <= levelsAvailable; i++)
        {
            var secondButton = GameObject.Instantiate(levelButtons.Last(), LevelMenu.transform);
            levelButtons.Add(secondButton);
            secondButton.GetComponent<RectTransform>().SetPositionAndRotation(new Vector3(456.5f + 37 + 40 * i, 225.5f), new Quaternion());
            var level = secondButton.AddComponent<Level>();
            level.sceneId = i;
            secondButton.GetComponent<Button>().onClick.AddListener(() => level.LoadScene());
            var text = secondButton.GetComponentInChildren<Text>();
            text.text = i.ToString();



        }
    }
    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        
        //settingsButton.SetActive(true);
    }

    public void ShowLevels()
    {
        
        MainMenu.SetActive(false);
        LevelMenu.SetActive(true);

        //button.SetActive(true);
        //secondButton.SetActive(true);
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
        LevelMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
