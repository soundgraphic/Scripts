using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver instance;
    public Image image;

    private void Awake()
    {
        instance = this;
        image.gameObject.SetActive(false);
    }

    public void Muerte()
    {
        image.gameObject.SetActive(true);
    }
}
