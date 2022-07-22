using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject play, credit, quit;
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void credits()
    {
        creditsPanel.SetActive(true);
        play.SetActive(false);
        credit.SetActive(false);
        quit.SetActive(false);
    }
    public void close()
    {
        creditsPanel.SetActive(false);
        play.SetActive(true);
        credit.SetActive(true);
        quit.SetActive(true);
    }
}
