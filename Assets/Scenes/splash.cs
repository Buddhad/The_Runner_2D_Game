using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class NewBehaviourScript : MonoBehaviour
{

    public static int SceneNumber;
    void Start()
    {
        if (SceneNumber == 0)
        {
            StartCoroutine(ToSplashTwo());
        }

        if (SceneNumber == 1)
        {
            StartCoroutine(ToMainMenu());
        }
    }

    IEnumerator ToSplashTwo()
    {
        yield return new WaitForSeconds(2);
        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }
    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneNumber = 2;
        SceneManager.LoadScene(2);

    }



}
