using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conservar : MonoBehaviour
{
    public Scene scene;
    public static Conservar instancia;
    private Canvas canvas;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
           
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    private void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Intro")
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }
}
