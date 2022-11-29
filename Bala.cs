using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velMovimiento;
    void Update()
    {
        transform.Translate (Vector3.forward * velMovimiento * Time.deltaTime);
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Contorno") || collision.gameObject.CompareTag("TanqueEnemigo"))
        {
            Destroy(gameObject);
        }
    }
}
 