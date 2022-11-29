using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public GameObject bala;

    public void Disparo()
    {
        Instantiate (bala, transform.position, transform.rotation);
    }
}