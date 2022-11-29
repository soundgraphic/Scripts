using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Reinicio : MonoBehaviour
{
    private int healthActual;
    public int maxHealth;
    public HealthBar healthBar;

    private void Start()
    {
        healthActual = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Tanque"))
        {
            //SceneManager.LoadScene("Escena_1", LoadSceneMode.Single);
            
            healthActual -= 1;
            healthBar.SetHealth(healthActual);
        }   
    }
}
