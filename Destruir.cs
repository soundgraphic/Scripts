using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public int numAciertos = 1;
    int cuentaAciertos;

    public GameObject explosion;
    public GameObject MeshGenerator;
    public IA_enemigo iA_Enemigo;

    int xSize;
    int zSize;

    private void Start()
    {
        xSize = MeshGenerator.GetComponent<MeshGenerator>().tamanoX / 2;
        zSize = MeshGenerator.GetComponent<MeshGenerator>().tamanoZ / 2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            //FindObjectOfType<AudioManager>().Play("Explosion");

            iA_Enemigo.DetenerCaza();

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(explosion, pos, rot);

            //CambiarPos();

            cuentaAciertos++;
            
            Score.instance.SumarPuntos();

            if (numAciertos == cuentaAciertos)
            {
                Destroy(gameObject);
            }
        }
    }

    private void CambiarPos()
    {
        transform.position = new Vector3(Random.Range(-xSize, xSize), 2f, Random.Range(-zSize, zSize));
    }
}
