using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;
    public QuestManager questManager;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void MenuButton()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        { 
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ReStartButton()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void TitileScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Save() // 병합하면  수정
    {
        PlayerPrefs.SetFloat("PlayerPositionX" , player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestID", questManager.questID);
        PlayerPrefs.SetInt("QuestActionNumber", questManager.questActionNumber);
        PlayerPrefs.Save();

    }

    public void Load() // 병합하면 수정
    {
        if (!PlayerPrefs.HasKey("PlayerPositionX"))
            return;

       float x = PlayerPrefs.GetFloat("PlayerPositionX");
       float y = PlayerPrefs.GetFloat("PlayerPositionY");
       int questID = PlayerPrefs.GetInt("QuestID" , questManager.questID);
       int questActionNumber = PlayerPrefs.GetInt("QuestActionNumber" , questManager.questActionNumber);

        player.transform.position = new Vector2(x, y);
        questManager.questID = questID;
        questManager.questActionNumber = questActionNumber;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
