using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
   public Button button;

   public AudioSource audioSource; 

    public void GameStartButton()
    {
        audioSource.Play();
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(1);
    }
}
