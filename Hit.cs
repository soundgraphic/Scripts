using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    private int healthActual;
    public int maxHealth;
    public HealthBar healthBar;
    public GameObject explosion;

    private void Start()
    {
        healthActual = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("BalaEnemigo"))
        {
            Instantiate(explosion, transform.position, transform.rotation);

            healthActual -= 1;
            healthBar.SetHealth(healthActual);

            if (healthActual == 0)
            {
                Movimiento.instance.Muerto();
                GameOver.instance.Muerte();

                Invoke("Intro", 5f);
            }
        }   
    }
    private void Intro()
    {
        SceneManager.LoadScene("Intro");
    }
}
