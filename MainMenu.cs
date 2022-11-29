using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Escena_1");
    }
    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("salida de la aplicación");
    }

    public void Intro ()
    {
        SceneManager.LoadScene("Intro");
    }
}
 
