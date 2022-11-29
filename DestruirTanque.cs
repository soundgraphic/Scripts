using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirTanque : MonoBehaviour
{
    public GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BalaEnemigo")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
