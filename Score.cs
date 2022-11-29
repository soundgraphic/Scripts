using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreTexto;
    int score;

    private void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        scoreTexto.text = "Score: " + score.ToString();
    }

    public void SumarPuntos()
    {
        score += 1;
        scoreTexto.text = "Score: " + score.ToString();
    }
}
