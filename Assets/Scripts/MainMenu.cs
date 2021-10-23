using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int n = 0;
    public void PlayGame(int n)
    {
        n++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + n); //+1 to mainmenu index --> starts level_1
    }

    public void QuitGame()
    {
        Application.Quit(); //exits the game
    }

    public void RestartGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex; //store the index of the current level
        SceneManager.LoadScene(currentScene); //call that scene back, enacting a restart
    }

    public void NextButton()
    {
        n++;
        PlayGame(n); //increments to next scene 
    }
}
